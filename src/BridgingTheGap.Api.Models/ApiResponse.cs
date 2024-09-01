namespace BridgingTheGap.Api.Models;

public class ApiResponse<T>
{
    public T Payload { get; set; } = default!;
}