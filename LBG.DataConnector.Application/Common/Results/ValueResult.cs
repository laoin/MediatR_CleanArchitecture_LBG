using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// Represents a results that returns a unique value.
    /// </summary>
    /// <typeparam name="T">type of element to return.</typeparam>
    public class ValueResult<T> : BaseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueResult{T}"/> class.
        /// </summary>
        public ValueResult()
        {
        }

        private ValueResult(ResultStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Gets or sets the result value.
        /// </summary>
        /// <summary>
        public T Data { get; set; }

        public static ValueResult<T> Ok()
        {
            return new ValueResult<T>(ResultStatus.Ok) {};
        }

        /// <summary>
        /// Gets a not found result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not found result.</returns>
        public static ValueResult<T> NotFound(params string[] errorMessages)
        {
            return new ValueResult<T>(ResultStatus.NotFound) { Errors = errorMessages };
        }

        /// <summary>
        /// Gets a no content result.
        /// </summary>
        /// <returns>Not content result.</returns>
        public static ValueResult<T> NoContent()
        {
            return new ValueResult<T>(ResultStatus.NoContent) { };
        }

        /// <summary>
        /// Gets a error result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not error result.</returns>
        public static ValueResult<T> Error(params string[] errorMessages)
        {
            return new ValueResult<T>(ResultStatus.Error) { Errors = errorMessages };
        }

        /// <summary>
        /// Returns an invalid result.
        /// </summary>
        /// <param name="validationErrors">List of errors.</param>
        /// <returns>invalid result.</returns>
        public static ValueResult<T> Invalid(List<ValidationError> validationErrors)
        {
            return new ValueResult<T>(ResultStatus.Invalid) { ValidationErrors = validationErrors };
        }
    }
}
