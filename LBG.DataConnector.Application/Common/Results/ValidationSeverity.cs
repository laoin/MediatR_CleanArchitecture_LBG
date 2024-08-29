using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// Severity of a validation message.
    /// </summary>
    public enum ValidationSeverity
    {
        /// <summary>
        /// Error.
        /// </summary>
        Error = 0,

        /// <summary>
        /// Warning.
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Information.
        /// </summary>
        Info = 2,

        /// <summary>
        /// Debug.
        /// </summary>
        Debug = 3,
    }
}
