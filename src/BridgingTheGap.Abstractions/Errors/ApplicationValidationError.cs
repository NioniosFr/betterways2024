namespace BridgingTheGap.Abstractions.Errors;

public sealed class ApplicationValidationError : Error
{
    public override ErrorType Type { get; } = ErrorType.Validation;

    /// <summary>
    /// An application validation error
    /// </summary>
    public ApplicationValidationError() { }

    /// <summary>
    /// An application validation error
    /// </summary>
    /// <param name="message">the error message</param>
    public ApplicationValidationError(string message) : base(message) { }

    /// <summary>
    /// An application validation error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ApplicationValidationError(string message, string code) : base(message, code) { }

    /// <summary>
    /// Get a default <see cref="ApplicationValidationError"/> instance
    /// </summary>
    public static ApplicationValidationError Instance { get; } = new("Your request was not valid, please review your request and try again");
}

public sealed class ApplicationValidationError<TPayload> : Error<TPayload>
{
    public override ErrorType Type { get; } = ErrorType.Validation;

    /// <summary>
    /// An application validation error
    /// </summary>
    public ApplicationValidationError() { }

    /// <summary>
    /// An application validation error
    /// </summary>
    /// <param name="message">the error message</param>
    public ApplicationValidationError(string message) : base(message) { }

    /// <summary>
    /// An application validation error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public ApplicationValidationError(string message, string code) : base(message, code) { }

    /// <summary>
    /// An application validation error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="payload"></param>
    public ApplicationValidationError(string message, string code, TPayload payload) : base(message, code)
    {
        Payload = payload;
    }

    /// <summary>
    /// Get a default <see cref="ApplicationValidationError{TPayload}"/>
    /// </summary>
    public static ApplicationValidationError<TPayload> Instance { get; } = new("Your request was not valid, please review your request and try again");
}
