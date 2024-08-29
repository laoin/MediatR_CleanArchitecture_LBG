using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// Represents a Result that can be returned by an API.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets the status of the call.
        /// </summary>
        ResultStatus Status { get; }

        /// <summary>
        /// Gets a value indicating whether if the result was Succesfull.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets the SuccessMessage.
        /// </summary>
        string SuccessMessage { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        IEnumerable<string> Errors { get; init; }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        List<ValidationError> ValidationErrors { get; }
    }
}
