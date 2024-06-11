namespace SportnetApi.Booking.Domain.Model.Queries;

public record CountSportNamesByLocationAndEventNameAndSportTypeQuery(
    string Location,
    string EventName,
    string SportType);
