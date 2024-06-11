using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Model.Commands;

namespace SportnetApi.Booking.Domain.Services;

/**
 *<summary>
 *  Interface for the sport event command service.
 * Defines the contract for the sport event command service.
 * </summary>
 */
public interface ISportEventCommandService
{
    Task<SportEvent?> Handle(CreateSportEventCommand command);
}