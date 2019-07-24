using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;

namespace RecipeApplication.Data.Artefact.Content
{
    [DataContract]
    public partial class Ingredient
    {
        #region Fields

        private enum Fields
        {
            Id,
            Ingredient,
            RecipeId
        }

        #endregion Fields


        public Ingredient(SqlDataReader reader)
        {
            this.Id = reader.GetInt32((int)Fields.Id);
            this.IngredientName = reader.GetString((int)Fields.Ingredient);
            this.RecipeId = reader.GetInt32((int)Fields.RecipeId);
        }

        public Ingredient()
        {
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }


        [DataMember]
        public string IngredientName
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
