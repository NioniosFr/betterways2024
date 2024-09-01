namespace BridgingTheGap.Abstractions.Errors;

/// <summary>
/// A domain error object <br></br>
/// This should be the error result type of the CQRS flow from application code.
/// </summary>
public abstract class Error
{
    protected Error() { }

    protected Error(string message)
    {
        Message = message;
    }

    protected Error(string message, string code) : this(message)
    {
        Code = code;
    }

    /// <summary>
    /// The error type
    /// </summary>
    public abstract ErrorType Type { get; }

    /// <summary>
    /// The error Message
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// The application error code
    /// </summary>
    public string Code { get; init; }
}

/// <summary>
/// This is the generic version of <see cref="Error"/> object.
/// It was created to include payload where needed.
/// </summary>
/// <typeparam name="TPayload"></typeparam>
public abstract class Error<TPayload> : Error
{
    protected Error() { }

    protected Error(string message) : base(message) { }

    protected Error(string message, string code) : base(message, code) { }

    /// <summary>
    /// The error's custom data
    /// </summary>
    public TPayload Payload { get; init; }
}
