using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact.Common
{
    [DataContract]
    public partial class Error : Common.Artefact
    {
        #region Fields

        private int _errorNumber;
        private string _message;
        private string _property;

        #endregion

        #region Properties

        #region ErrorNumber

        [DataMember]
        public int ErrorNumber
        {
            get { return _errorNumber; }
            set { _errorNumber = value; }
        }

        #endregion

        #region Message

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion

        #region PropertyName

        [DataMember]
        public string PropertyName
        {
            get { return _property; }
            set { _property = value; }
        }

        #endregion

        #endregion

        #region Ctors and Dtor

        public Error()
        {
            _errorNumber = 0;
            _message = null;
            _property = null;
        }

        internal Error(int errorNumber, string description)
        {
            _errorNumber = errorNumber;
            _message = description;
            _property = null;
        }

        internal Error(int errorNumber, string description, string property)
        {
            _errorNumber = errorNumber;
            _message = description;
            _property = property;
        }

        #endregion
    }
}
