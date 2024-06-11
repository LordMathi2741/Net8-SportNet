using SportnetApi.Booking.Domain.Model.Commands;
using SportnetApi.Booking.Interface.Rest.Resources;

namespace SportnetApi.Booking.Interface.Rest.Transform;

public class CreateSportEventCommandFromResourceAssembler
{
    public static CreateSportEventCommand ToCommandFromResource (CreateSportEventResource resource)
    {
        return new CreateSportEventCommand(resource.EventName, resource.SportType, resource.OrganizerId,
            resource.Location, resource.Capacity);
    }
}