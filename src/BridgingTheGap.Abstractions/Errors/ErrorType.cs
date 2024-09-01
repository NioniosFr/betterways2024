namespace BridgingTheGap.Abstractions.Errors;

/// <summary>
/// Domain Error Types
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// This describes a server failure
    /// </summary>
    ServerFailure = 0,

    /// <summary>
    /// This is a generic error
    /// </summary>
    Generic = 1,

    /// <summary>
    /// A downstream service circuit is broken
    /// </summary>
    BrokenCircuit = 2,

    /// <summary>
    /// A resource is missing
    /// </summary>
    ResourceNotFound = 3,

    /// <summary>
    /// A validation flow has failed
    /// </summary>
    Validation = 4,
}
