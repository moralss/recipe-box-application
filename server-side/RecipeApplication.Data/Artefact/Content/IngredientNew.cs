using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RecipeApplication.Data.Artefact.Content
{
    [DataContract]
    public class IngredientNew : Common.Artefact
    {

        #region Constructors

        public IngredientNew() { }


        #endregion Constructors

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Ingredient
        {
            get;
            set;
        }


        [DataMember]
        public int RecipeId
        {
            get;
            set;
        }
    }
}
