using System;
using BridgingTheGap.Abstractions.Errors;
using BridgingTheGap.Api.Models;

namespace BridgingTheGap.Host.Api.Extensions;

public static class ApiErrorResponseExtensions
{
    /// <summary>
    /// Maps an <see cref="Error"/> to <see cref="ApiErrorResponse"/>
    /// </summary>
    /// <param name="error">the application error object</param>
    /// <returns></returns>
    public static ApiErrorResponse ToApiErrorResponse(this Error error)
        => FromErrorBase<ApiErrorResponse>(error);

    /// <summary>
    /// Maps an <see cref="Error{TPayload}"/> to <see cref="ApiErrorResponse{TPayload}"/>
    /// </summary>
    /// <typeparam name="TApiErrorPayload"></typeparam>
    /// <typeparam name="TErrorPayload"></typeparam>
    /// <param name="error">the application error object with generic payload</param>
    /// <param name="mapper">the mapper to handle the payload mapping from domain to api</param>
    /// <returns></returns>
    public static ApiErrorResponse<TApiErrorPayload> ToApiErrorResponse<TApiErrorPayload, TErrorPayload>(
        this Error<TErrorPayload> error,
        Func<TErrorPayload, TApiErrorPayload> mapper)
    {
        var apiErrorResponse = FromErrorBase<ApiErrorResponse<TApiErrorPayload>>(error);
        apiErrorResponse.Payload = mapper(error.Payload);

        return apiErrorResponse;
    }

    private static TApiErrorResponse FromErrorBase<TApiErrorResponse>(Error error)
        where TApiErrorResponse : ApiErrorResponse, new() =>
        new()
        {
            Status = error.GetHttpStatusCode(),
            Title = error.GetTitle(),
            Details = error.Message,
            Code = error.Code
        };
}