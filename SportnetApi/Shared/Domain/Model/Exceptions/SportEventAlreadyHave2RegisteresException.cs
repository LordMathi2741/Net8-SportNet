namespace SportnetApi.Shared.Domain.Model.Exceptions;

public class SportEventAlreadyHave2RegisteresException : Exception
{
    public SportEventAlreadyHave2RegisteresException(string message) : base(message)
    {
    }
    
    public SportEventAlreadyHave2RegisteresException(string message, Exception innerException) : base(message, innerException)
    {
    }
}