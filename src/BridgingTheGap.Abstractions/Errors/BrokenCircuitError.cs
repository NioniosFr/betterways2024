namespace BridgingTheGap.Abstractions.Errors;

public sealed class BrokenCircuitError : Error
{
    public override ErrorType Type { get; } = ErrorType.BrokenCircuit;

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    public BrokenCircuitError() { }

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    /// <param name="message">the error message</param>
    public BrokenCircuitError(string message) : base(message) { }

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public BrokenCircuitError(string message, string code) : base(message, code) { }

    /// <summary>
    /// Get a default <see cref="BrokenCircuitError"/> instance
    /// </summary>
    public static BrokenCircuitError Instance { get; } = new("This service is unavailable. Unreachable downstream services detected. Please try again later");
}

public sealed class BrokenCircuitError<TPayload> : Error<TPayload>
{
    public override ErrorType Type { get; } = ErrorType.BrokenCircuit;

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    public BrokenCircuitError() { }

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    /// <param name="message">the error message</param>
    public BrokenCircuitError(string message) : base(message) { }

    /// <summary>
    /// An application broken circuit error
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="code">the application error code</param>
    public BrokenCircuitError(string message, string code) : base(message, code) { }

    /// <summary>
    /// An application broken circuit error with payload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="payload"></param>
    public BrokenCircuitError(string message, string code, TPayload payload) : base(message, code)
    {
        Payload = payload;
    }

    /// <summary>
    /// Get a default <see cref="BrokenCircuitError{TPayload}"/> instance
    /// </summary>
    public static BrokenCircuitError<TPayload> Instance { get; } = new("This service is unavailable. Unreachable downstream services detected. Please try again later");
}
