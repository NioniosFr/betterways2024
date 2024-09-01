namespace BridgingTheGap.Abstractions.Errors;

public sealed class ResourceNotFoundError : Error
{
    public override ErrorType Type { get; } = ErrorType.ResourceNotFound;

    /// <summary>
    /// A resource is not found error
    /// </summary>
    public ResourceNotFoundError() { }

    /// <summary>
    /// A resource is not found error
    /// </summary>
    /// <param name="message">the error message</param>
    public ResourceNotFoundError(string message) : base(message) { }

    /// <summary>
    /// A resource is not found error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ResourceNotFoundError(string message, string code) : base(message, code) { }

    /// <summary>
    /// Get a default <see cref="ResourceNotFoundError"/> instance
    /// </summary>
    public static ResourceNotFoundError Instance { get; } = new("The requested resource was not found");
}

public sealed class ResourceNotFoundError<TPayload> : Error<TPayload>
{
    public override ErrorType Type { get; } = ErrorType.ResourceNotFound;

    /// <summary>
    /// A resource is not found error
    /// </summary>
    public ResourceNotFoundError() { }

    /// <summary>
    /// A resource is not found error
    /// </summary>
    /// <param name="message">the error message</param>
    public ResourceNotFoundError(string message) : base(message) { }

    /// <summary>
    /// A resource is not found error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ResourceNotFoundError(string message, string code) : base(message, code) { }

    /// <summary>
    /// A resource is not found error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="payload"></param>
    public ResourceNotFoundError(string message, string code, TPayload payload) : base(message, code)
    {
        Payload = payload;
    }

    /// <summary>
    /// Get a default <see cref="ResourceNotFoundError{TPayload}"/> instance
    /// </summary>
    public static ResourceNotFoundError<TPayload> Instance { get; } = new("The requested resource was not found");
}
