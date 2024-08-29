using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    /// <summary>
    /// Represents a validation error.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets or sets the Property that generated the error.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the Validation Error Message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Severity of this Error.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter<ValidationSeverity>))]
        public ValidationSeverity Severity { get; set; } = ValidationSeverity.Error;
    }
}
