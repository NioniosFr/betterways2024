using System.Net;
using BridgingTheGap.Abstractions.Errors;

namespace BridgingTheGap.Host.Api.Extensions;

public static class ErrorExtensions
{
    /// <summary>
    /// Maps the <see cref="ErrorType"/> to http status code
    /// </summary>
    /// <param name="error">the application error</param>
    /// <returns></returns>
    public static int GetHttpStatusCode(this Error error) =>
        error.Type switch
        {
            ErrorType.ServerFailure => (int)HttpStatusCode.InternalServerError,
            ErrorType.Generic => (int)HttpStatusCode.BadRequest,
            ErrorType.BrokenCircuit => (int)HttpStatusCode.ServiceUnavailable,
            ErrorType.ResourceNotFound => (int)HttpStatusCode.NotFound,
            ErrorType.Validation => (int)HttpStatusCode.UnprocessableEntity,
            _ => (int)HttpStatusCode.InternalServerError,
        };

    /// <summary>
    /// Returns a generic title based on  <see cref="ErrorType"/>
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static string GetTitle(this Error error) =>
        error.Type switch
        {
            ErrorType.ServerFailure => "Server Error",
            ErrorType.Generic => "Bad Request",
            ErrorType.BrokenCircuit => "Downstream Service Unavailable",
            ErrorType.ResourceNotFound => "Not Found",
            ErrorType.Validation => "Validation Error",
            _ => "Unknown Error",
        };
}
