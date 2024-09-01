namespace BridgingTheGap.Abstractions.Errors;

public sealed class ServerError : Error
{
    public override ErrorType Type { get; } = ErrorType.ServerFailure;

    /// <summary>
    /// An application server error
    /// </summary>
    public ServerError() { }

    /// <summary>
    /// An application server error
    /// </summary>
    /// <param name="message">the error message</param>
    public ServerError(string message) : base(message) { }

    /// <summary>
    /// An application server error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ServerError(string message, string code) : base(message, code) { }

    /// <summary>
    /// Get a default <see cref="ServerError"/> instance
    /// </summary>
    public static ServerError Instance { get; } = new("Something is not working - It's not you, it's us");
}

public sealed class ServerError<TPayload> : Error<TPayload>
{
    public override ErrorType Type { get; } = ErrorType.ServerFailure;

    /// <summary>
    /// An application server error
    /// </summary>
    public ServerError() { }

    /// <summary>
    /// An application server error
    /// </summary>
    /// <param name="message">the error message</param>
    public ServerError(string message) : base(message) { }

    /// <summary>
    /// An application server error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ServerError(string message, string code) : base(message, code) { }

    /// <summary>
    /// An application server error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="payload"></param>
    public ServerError(string message, string code, TPayload payload) : base(message, code)
    {
        Payload = payload;
    }

    /// <summary>
    /// Get a default <see cref="ServerError{TPayload}"/> instance
    /// </summary>
    public static ServerError<TPayload> Instance { get; } = new("Something is not working - It's not you, it's us");
}
