using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// A result that doesn't need to return any value.
    /// </summary>
    public sealed class VoidResult : BaseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoidResult"/> class.
        /// </summary>
        public VoidResult()
        {
        }

        private VoidResult(ResultStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Returns a Successful result.
        /// </summary>
        /// <returns>succesful result.</returns>
        public static VoidResult Success()
        {
            return new VoidResult();
        }

        /// <summary>
        /// Returns a Successful result.
        /// </summary>
        /// <param name="successMessage">Ok message.</param>
        /// <returns>Succesful result.</returns>
        public static VoidResult Success(string successMessage)
        {
            return new VoidResult() { SuccessMessage = successMessage };
        }

        /// <summary>
        /// Returns an Error result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>error result.</returns>
        public static VoidResult Error(params string[] errorMessages)
        {
            return new VoidResult(ResultStatus.Error) { Errors = errorMessages };
        }

        /// <summary>
        /// Returns an invalid result.
        /// </summary>
        /// <param name="validationErrors">List of errors.</param>
        /// <returns>invalid result.</returns>
        public static VoidResult Invalid(List<ValidationError> validationErrors)
        {
            return new VoidResult(ResultStatus.Invalid) { ValidationErrors = validationErrors };
        }

        /// <summary>
        /// Gets a not found result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not found result.</returns>
        public static VoidResult NotFound(params string[] errorMessages)
        {
            return new VoidResult(ResultStatus.NotFound) { Errors = errorMessages };
        }

        /// <summary>
        /// Gets a forbidden result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>forbidden result.</returns>
        public static VoidResult Forbidden(params string[] errorMessages)
        {
            return new VoidResult(ResultStatus.Forbidden);
        }
    }
}
