using BridgingTheGap.Abstractions.Errors;

namespace BridgingTheGap.Abstractions;

public class HandlerResult<TData, TError> where TError : Error
{
    /// <summary>
    /// Actual data after a valid flow
    /// </summary>
    public TData? Data { get; }

    /// <summary>
    /// An error object that describes the fault, in case of invalid flow
    /// </summary>
    public TError? Error { get; }

    /// <summary>
    /// The flag that indicates if the <see cref="HandlerResult{TData, TError}"/> is successful
    /// </summary>
    public bool IsSuccess => Error is null;

    protected HandlerResult()
    {
    }

    protected HandlerResult(TData data)
    {
        Data = data;
    }

    protected HandlerResult(TError error)
    {
        Error = error;
    }

    public static HandlerResult<TData, TError> Ok(TData data)
        => new(data);

    public static HandlerResult<TData, TError> Nok(TError error)
        => new(error);
}

public sealed class HandlerResult<TData> : HandlerResult<TData, Error>
{
    private HandlerResult(TData data) : base(data)
    {
    }

    private HandlerResult(Error error) : base(error)
    {
    }

    public new static HandlerResult<TData> Nok(Error error)
        => new(error);

    public new static HandlerResult<TData> Ok(TData data)
        => new(data);
}
