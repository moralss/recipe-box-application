using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact.Common
{
    [CollectionDataContract]
    public class ErrorList : List<Error>
    {
    }
}
