using System;
using System.Xml.Serialization;

namespace RecipeApplication.Data.Artefact.Common
{
    /// <summary>
    /// Indicates the execution status of the command.
    /// </summary>
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "SolutionName")]
    [XmlRoot(Namespace = "SolutionName", IsNullable = false)]
    public enum CallReturnState
    {
        /// <summary>
        /// The command executed successfully
        /// </summary>
        Success = 0,
        /// <summary>
        /// The command exectued, however warnings were returned bringing important
        /// information to the users attentin
        /// </summary>
        Warning = 1,
        /// <summary>
        /// The command did not execute and errors were returned
        /// </summary>
        Failure = 2,
        /// <summary>
        /// Validation errors, bring information to the users attention
        /// </summary>
        ValidationError = 3
    }
}
