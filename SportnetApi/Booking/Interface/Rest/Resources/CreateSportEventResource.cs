namespace SportnetApi.Booking.Interface.Rest.Resources;

public record CreateSportEventResource(string EventName, string SportType, long OrganizerId, string Location, int Capacity);