using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApplication.Data.Artefact.Common
{
    public enum ErrorType
    {
        UNKNOWN,
        SystemError,
        AdminOnly,
        Serialization_Faillure,
        Authorisation_AccountLockedOut,
        Authorisation_Denied,
        UserExists,
        EmailSending_Failure,
        Token_Failure,
        Registration_Failure,
        JSONFormat,
        FieldMapping,
        Unauthorized
    }
}
