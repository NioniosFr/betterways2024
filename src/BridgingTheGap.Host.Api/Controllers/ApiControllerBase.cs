using System;
using System.Net;
using BridgingTheGap.Abstractions;
using BridgingTheGap.Abstractions.Errors;
using BridgingTheGap.Host.Api.Extensions;
using BridgingTheGap.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BridgingTheGap.Host.Api.Controllers;

public class ApiControllerBase : ControllerBase
{
    /// <summary>
    /// Wraps the response within an <see cref="ApiResponse{T}"/> object containing payload and action metadata info<br></br>
    /// Maps <see cref="HandlerResult{T}"/> to HTTP action results.
    /// </summary>
    /// <param name="handlerResult"></param>
    /// <param name="viewModelMapper"></param>
    /// <param name="actionMapper"></param>
    /// Must be in the range of successful Status Codes, otherwise an <see cref="ArgumentOutOfRangeException"/> will be thrown.</param>
    /// <typeparam name="TData">Type of Domain model</typeparam>
    /// <typeparam name="TApiModel">Maps the Domain models to Api models</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    protected IStatusCodeActionResult HandleResult<TData, TApiModel>(HandlerResult<TData> handlerResult,
        Func<TData, TApiModel> viewModelMapper)
    {
        return handlerResult.IsSuccess
            ? ToJsonResultResponse(handlerResult, viewModelMapper, HttpStatusCode.OK)
            : StatusCode(handlerResult.Error!.GetHttpStatusCode(), handlerResult.Error!.ToApiErrorResponse());
    }

    /// <summary>
    /// Wraps the response within an <see cref="ApiResponse{T}"/> object containing payload and action metadata info<br></br>
    /// Maps <see cref="HandlerResult{T}"/> to HTTP action results.
    /// </summary>
    /// <typeparam name="TData">The success response payload type</typeparam>
    /// <typeparam name="TErrorPayload">The error response payload</typeparam>
    /// <typeparam name="TApiModel">the success flow api model</typeparam>
    /// <typeparam name="TErrorApiPayload">the error response api payload type</typeparam>
    /// <param name="handlerResult">the handler result</param>
    /// <param name="viewModelMapper">the success result payload mapper to api model</param>
    /// <param name="errorPayloadMapper">the error result payload mapper to error api model</param>
    /// <param name="successResultStatusCode">the success response status code. If the result is erroneous then the status code is created based on error</param>
    /// <returns></returns>
    protected IStatusCodeActionResult HandleResult<TData, TErrorPayload, TApiModel, TErrorApiPayload>(
        HandlerResult<TData, Error<TErrorPayload>> handlerResult,
        Func<TData, TApiModel> viewModelMapper,
        Func<TErrorPayload, TErrorApiPayload> errorPayloadMapper,
        HttpStatusCode successResultStatusCode) =>
        HandleResult(handlerResult, viewModelMapper, error => error.ToApiErrorResponse(errorPayloadMapper),
            successResultStatusCode);

    /// <summary>
    /// Wraps the response within an <see cref="ApiResponse{T}"/> object containing payload and action metadata info<br></br>
    /// Maps <see cref="HandlerResult{T}"/> to HTTP action results.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TApiModel"></typeparam>
    /// <typeparam name="TErrorApiModel"></typeparam>
    /// <param name="handlerResult"></param>
    /// <param name="viewModelMapper"></param>
    /// <param name="errorMapper"></param>
    /// <param name="successResultStatusCode">The HTTP status code in case of success result.
    /// Must be in the range of successful Status Codes, otherwise an <see cref="ArgumentOutOfRangeException"/> will be thrown.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private IStatusCodeActionResult HandleResult<TData, TError, TApiModel, TErrorApiModel>(
        HandlerResult<TData, TError> handlerResult,
        Func<TData, TApiModel> viewModelMapper,
        Func<TError, TErrorApiModel> errorMapper,
        HttpStatusCode successResultStatusCode)
        where TError : Error
        where TErrorApiModel : ApiErrorResponse
    {
        return handlerResult.IsSuccess
            ? ToJsonResultResponse(handlerResult, viewModelMapper, successResultStatusCode)
            : StatusCode(handlerResult.Error!.GetHttpStatusCode(), errorMapper(handlerResult.Error!));
    }

    private IStatusCodeActionResult ToJsonResultResponse<TData, TError, TApiModel>(
        HandlerResult<TData, TError> handlerResult,
        Func<TData, TApiModel> viewModelMapper,
        HttpStatusCode statusCode
    ) where TError : Error
    {
        var response = CreateApiResponse(handlerResult.Data, viewModelMapper);
        return CreateJsonResult(response, statusCode);
    }

    private static ApiResponse<TApiModel> CreateApiResponse<TData, TApiModel>(TData? data,
        Func<TData, TApiModel> viewModelMapper) =>
        new()
        {
            Payload = (data != null ? viewModelMapper(data) : default)!,
        };

    private JsonResult CreateJsonResult(object? value, HttpStatusCode statusCode) =>
        new(value)
        {
            ContentType = global::System.Net.Mime.MediaTypeNames.Application.Json,
            StatusCode = (int)statusCode
        };
}