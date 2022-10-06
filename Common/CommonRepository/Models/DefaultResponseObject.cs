using Ardalis.Result;

namespace CommonRepository.Models;

public class DefaultResponseObject<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public string[]? Errors { get; set; }
    public ValidationError[]? ValidationErrors { get; set; }
}
