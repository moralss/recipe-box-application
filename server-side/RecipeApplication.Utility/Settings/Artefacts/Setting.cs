using System;
using System.Data;
using System.Runtime.Serialization;

namespace RecipeApplication.Utility.Settings.Artefacts
{
    [DataContract]
    public class Setting
    {
        #region Index

        public enum Index
        {
        }

        #endregion Index

        #region Fields

        private enum Fields
        {
            Id,
            RecipeName,
            Ingredients,
        }

        #endregion Fields

        #region Constructors

        public Setting() { }

        public Setting(IDataReader reader)
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