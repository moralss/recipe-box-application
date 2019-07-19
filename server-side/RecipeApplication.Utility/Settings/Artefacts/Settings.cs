using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RecipeApplication.Utility.Settings.Artefacts
{
    [CollectionDataContract]
    public class Settings : List<Setting>
    {
        public string HashInstance
        {
            get
            {
                return "HashInstance";
            }
        }
    }
}