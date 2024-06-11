namespace SportnetApi.Booking.Domain.Model.ValueObjects;

/// <summary>
///   Value object that represents the identifier of an organizer.
///  It is a long number.
///   It is a value object.
///   Declares as record for immutability.
/// </summary>
/// <param name="Id"></param>
public record OrganizerId(long OrganizerIdValue)
{
    public OrganizerId(): this(0)
    {
        
    }
    
}