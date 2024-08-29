using LBG.DataConnector.Application.Common.Results;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LBG.DataConnector.Common.Utilities
{
    public static class SafeExecutionExtensions
    {
        public static async Task<Microsoft.AspNetCore.Http.IResult> Execute(Func<Task<Microsoft.AspNetCore.Http.IResult>> action, ILogger logger)
        {
            try
            {
                return await action();
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError(ex, "Unauthorized access error.");
                var responseError = new Application.Common.Results.ValueResult<IEnumerable<UnsubmittedDataBriefDto>>
                {
                    Status = Application.Common.Results.ResultStatus.Error,
                    Errors = new List<string> { ex.Message }
                };
                return Results.Json(responseError, statusCode: (int)HttpStatusCode.Unauthorized);
            }
            catch (KeyNotFoundException ex)
            {
                logger.LogError(ex, "Key not found error.");
                var responseError = new Application.Common.Results.ValueResult<IEnumerable<UnsubmittedDataBriefDto>>
                {
                    Status = Application.Common.Results.ResultStatus.Error,
                    Errors = new List<string> { ex.Message }
                };
                return Results.NotFound(responseError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Internal server error.");
                var responseError = new ValueResult<IEnumerable<UnsubmittedDataBriefDto>>
                {
                    Status = ResultStatus.Error,
                    Errors = new List<string> { ex.Message }
                };
                return Results.Json(responseError, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }
    }
}
