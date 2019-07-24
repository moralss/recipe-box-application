using System.Runtime.Serialization;
using System.Data;

namespace RecipeApplication.Data.Artefact
{
    [DataContract]
    public class RecipeNew : Common.Artefact
    {
        #region Constructors
        public RecipeNew() { }

        #endregion Constructors

        #region Public properties

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string RecipeName
        {
            get;
            set;
        }

  //      [DataMember]
    //    public string Ingredients
      //  {
    //        get;
  //          set;
      //  }


      
        #endregion Public properties
    }
}
