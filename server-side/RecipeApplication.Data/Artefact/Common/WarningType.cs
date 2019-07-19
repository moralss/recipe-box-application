using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApplication.Data.Artefact.Common
{
    public enum WarningType
    {
        Unknown = -0x4FFFFFFF,  // we base WarningTypes on negative numbers so that they are not confused with ErrorTypes
        SessionNotFound,
        InvalidEmailAddress
    }
}
