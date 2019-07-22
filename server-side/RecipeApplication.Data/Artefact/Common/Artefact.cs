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

    

  
        public void SetDefaults()
        {
   
        }

    }
}
