using System;
using System.Runtime.Serialization;

namespace RecipeApplication.Utility.Settings.Artefacts
{
    [DataContract]
    public class SettingNew
    {
        #region Constructors

        public SettingNew() { }

        #endregion Constructors

        #region Public properties

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Key
        {
            get;
            set;
        }

        [DataMember]
        public string Value
        {
            get;
            set;
        }

        [DataMember]
        public string Comment
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }

        [DataMember]
        public int ModifiedUserId
        {
            get;
            set;
        }

        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        #endregion Public properties
    }
}