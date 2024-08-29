using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Results
{
    public class BaseResult: IResult
    {
        private readonly ResultStatus[] _successStatuses = new ResultStatus[]
        {
            ResultStatus.Ok,
            ResultStatus.NoContent,
            ResultStatus.Halt,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResult"/> class.
        /// </summary>
        public BaseResult()
        {
        }

        /// <inheritdoc/>
        [JsonConverter(typeof(JsonStringEnumConverter<ResultStatus>))]
        public ResultStatus Status { get; init; } = ResultStatus.Ok;

        /// <inheritdoc/>
        [JsonIgnore]
        public bool IsSuccess => _successStatuses.Contains(Status);

        /// <inheritdoc/>
        public string SuccessMessage { get; set; } = string.Empty;

        /// <inheritdoc/>
        public IEnumerable<string> Errors { get; init; } = new List<string>();

        /// <inheritdoc/>
        public List<ValidationError> ValidationErrors { get; init; } = new List<ValidationError>();

    }
}
