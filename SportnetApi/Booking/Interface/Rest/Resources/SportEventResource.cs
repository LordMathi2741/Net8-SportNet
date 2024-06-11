namespace SportnetApi.Booking.Interface.Rest.Resources;

public record SportEventResource(long Id, string EventName, string SportType, long OrganizerId, string Location, int Capacity);