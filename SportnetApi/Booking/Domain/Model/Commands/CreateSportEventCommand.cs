using SportnetApi.Shared.Domain.Model.Exceptions;

namespace SportnetApi.Booking.Domain.Model.Commands;

/**
 * <summary>
 * Command to create a sport event.
 * Declares as record to make it immutable.
 * </summary>
 */
public record CreateSportEventCommand(
    string EventName,
    string SportType,
    long OrganizerId,
    string Location,
    int Capacity);
