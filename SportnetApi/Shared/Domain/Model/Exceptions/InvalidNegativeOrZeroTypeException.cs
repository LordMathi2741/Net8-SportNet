namespace SportnetApi.Shared.Domain.Model.Exceptions;

public class InvalidNegativeOrZeroTypeException : Exception
{
    public InvalidNegativeOrZeroTypeException(string message) : base(message)
    {
    }
    
    public InvalidNegativeOrZeroTypeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}