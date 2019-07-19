using System.Data;
using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact.Content
{
    [DataContract]
    public partial class  Recipe: Common.Artefact
    {
        #region Fields

        private enum Fields
        {
            Id,
            RecipeName,
            Ingredients
        }

        #endregion Fields

        #region Constructors

        public Recipe() { }

        public Recipe(IDataReader reader)
        {
            if (reader != null)
            {
                this.Id = reader.GetInt32((int)Fields.Id);
                this.RecipeName = reader.GetString((int)Fields.RecipeName);
                this.Ingredients = reader.GetString((int)Fields.Ingredients);
            }
        }

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


        [DataMember]
        public string Ingredients
        {
            get;
            set;
        }

        #endregion Public properties
    }
}