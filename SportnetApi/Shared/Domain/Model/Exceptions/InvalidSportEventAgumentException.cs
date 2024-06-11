namespace SportnetApi.Shared.Domain.Model.Exceptions;

public class InvalidSportEventAgumentException : Exception
{
    public InvalidSportEventAgumentException(string message) : base(message)
    {
    }
    
    public InvalidSportEventAgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }
}