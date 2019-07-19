namespace RecipeApplication.Data.Artefact.Common
{
    internal static class ErrorMessageHelper
    {
        #region Methods

        internal static string GetErrorText(ErrorType errorType, params object[] errorParameters)
        {
            switch (errorType)
            {
                case ErrorType.Authorisation_AccountLockedOut:
                    {
                        if (errorParameters.Length > 0)
                            return string.Format("Your account has been locked out. Please try again in {0} minutes or contact your system administrator.", errorParameters);
                        else
                            return "Your account has been locked out. Please try again in a few minutes or contact your system administrator.";
                    }
                case ErrorType.Authorisation_Denied:
                    {
                        if (errorParameters.Length > 0)
                            return string.Format("Your username and/or password is incorrect. Your account will be locked after {0} attempts.", errorParameters);
                        else
                            return "Your username and/or password is incorrect.";
                    }

                case ErrorType.SystemError:
                    {
                        if (errorParameters.Length > 0)
                            return string.Format("There was a system error ({0}).", errorParameters);
                        else
                            return "There was a system error.";
                    }

                case ErrorType.AdminOnly:
                    {
                        if (errorParameters.Length > 0)
                            return string.Format("Only system administrators can perform this action. ({0}).", errorParameters);
                        else
                            return "Only system administrators can perform this action.";
                    }


                default:
                    {
                        if (errorParameters.Length > 0)
                            return string.Format("{1} ({0})", errorType.ToString(), errorParameters[0]);
                        else
                            return string.Format("An error has occurred ({0}).", errorType.ToString());
                    }
            }
        }

        internal static string GetWarningText(WarningType warningType, params object[] warningParameters)
        {
            switch (warningType)
            {
                #region Business Rule Warnings

                #endregion

                case WarningType.SessionNotFound:
                    {
                        if (warningParameters.Length > 0)
                            return string.Format("The session could not be found. ({0})", warningParameters[0]);
                        else
                            return string.Format("The session could not be found.");
                    }

                case WarningType.Unknown:
                    {
                        if (warningParameters.Length > 0)
                            return string.Format("{1} ({0})", warningType.ToString(), warningParameters[0]);
                        else
                            return string.Format("A warning has occurred ({0}).", warningType.ToString());
                    }

                case WarningType.InvalidEmailAddress:
                    {
                        if (warningParameters.Length > 0)
                            return string.Format("{1} ({0})", warningType.ToString(), warningParameters[0]);
                        else
                            return string.Format("Invalid email address ({0}).", warningType.ToString());
                    }

                default:
                    {
                        if (warningParameters.Length > 0)
                            return string.Format("{1} ({0})", warningType.ToString(), warningParameters[0]);
                        else
                            return string.Format("A warning has occurred ({0}).", warningType.ToString());
                    }
            }
        }

        #endregion
    }
}