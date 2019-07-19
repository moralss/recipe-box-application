using System;
using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact.Common
{
    public class CallReturn<T>
    {

        #region Attributes

        /// <summary>
        /// Contains the state of the call.
        /// </summary>
        [DataMember]
        public CallReturnState State;

        #endregion

        #region Elements

        /// <summary>
        /// Contains a list of errors.
        /// </summary>
        [DataMember]
        public ErrorList Errors = new ErrorList();

        /// <summary>
        /// Contains the returned object.
        /// </summary>
        public T Object { get; set; }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="ex"></param>
        internal void SetError(ErrorType errorType, Exception ex)
        {
            State = CallReturnState.Failure;

            Error item = new Error((int)errorType, ex.Message.Replace(Environment.NewLine, ""));

            if (!Errors.Contains(item))
            {
                Errors.Add(item);
            }
        }

        internal void SetError(ErrorType errorType, params object[] args)
        {
            State = CallReturnState.Failure;

            var item = new Error((int)errorType, ErrorMessageHelper.GetErrorText(errorType, args));

            if (!Errors.Contains(item))
                Errors.Add(item);
        }
    }
}
