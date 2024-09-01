namespace BridgingTheGap.Abstractions.Errors;

/// <summary>
/// A generic application error
/// </summary>
public sealed class GenericError : Error
{
    public override ErrorType Type { get; } = ErrorType.Generic;

    /// <summary>
    /// An application generic error
    /// </summary>
    public GenericError() { }

    /// <summary>
    /// An application generic error
    /// </summary>
    /// <param name="message">the error message</param>
    public GenericError(string message) : base(message) { }

    /// <summary>
    /// An application generic error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public GenericError(string message, string code) : base(message, code) { }

    /// <summary>
    /// Get a default <see cref="GenericError"/> instance
    /// </summary>
    public static GenericError Instance { get; } = new("We are sorry, we are not able to process your request");
}

/// <summary>
/// An generic application error with custom payload
/// </summary>
/// <typeparam name="TPayload"></typeparam>
public sealed class GenericError<TPayload> : Error<TPayload>
{
    public override ErrorType Type { get; } = ErrorType.Generic;

    /// <summary>
    /// An application generic error with payload
    /// </summary>
    public GenericError() { }

    /// <summary>
    /// An application generic error with payload
    /// </summary>
    /// <param name="message">the error message</param>
    public GenericError(string message) : base(message) { }

    /// <summary>
    /// An application generic error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="payload"></param>
    public GenericError(string message, TPayload payload) : base(message)
    {
        Payload = payload;
    }

    /// <summary>
    /// An application generic error with payload
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public GenericError(string message, string code) : base(message, code) { }

    /// <summary>
    /// An application generic error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="payload"></param>
    public GenericError(string message, string code, TPayload payload) : base(message, code)
    {
        Payload = payload;
    }

    /// <summary>
    /// Get a default <see cref="GenericError{TPayload}"/> instance
    /// </summary>
    public static GenericError<TPayload> Instance { get; } = new("We are sorry, we are not able to process your request");
}
