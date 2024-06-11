using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Interface.Rest.Resources;

namespace SportnetApi.Booking.Interface.Rest.Transform;

public class SportEventResourceFromEntityAssembler
{
    public static SportEventResource ToResourceFromEntity(SportEvent sportEvent)
    {
        return new SportEventResource(sportEvent.Id, sportEvent.EventName, sportEvent.SportType, sportEvent.OrganizerId,
            sportEvent.Location, sportEvent.Capacity);
    }
}