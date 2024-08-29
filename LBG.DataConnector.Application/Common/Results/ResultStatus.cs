using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// Result Status.
    /// </summary>
    public enum ResultStatus
    {
        /// <summary>
        /// 200, Ok.
        /// </summary>
        Ok,

        /// <summary>
        /// 500, Error
        /// </summary>
        Error,

        /// <summary>
        /// Forbidden.
        /// </summary>
        Forbidden,

        /// <summary>
        /// 400, Invalid, Bad request
        /// </summary>
        Invalid,

        /// <summary>
        /// 404, Not found
        /// </summary>
        NotFound,

        /// <summary>
        /// 204, No content
        /// </summary>
        NoContent,

        /// <summary>
        /// Halt the process until the result is ready.
        /// </summary>
        Halt,
    }
}
