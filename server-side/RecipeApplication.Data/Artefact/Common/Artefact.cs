using System;
using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact.Common
{
    [DataContract]
    public abstract class Artefact
    {
        protected Artefact()
        {
            SetDefaults();
        }

        [DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }

        [DataMember]
        public Int32? ModifiedUserId
        {
            get;
            set;
        }

        [DataMember]
        public Boolean IsActive
        {
            get;
            set;
        }

        public void SetDefaults()
        {
            this.IsActive = true;
            this.ModifiedUserId = 1; //Admin user...
        }

    }
}
