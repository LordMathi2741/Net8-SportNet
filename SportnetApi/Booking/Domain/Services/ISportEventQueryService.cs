using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Model.Queries;

namespace SportnetApi.Booking.Domain.Services;

/**
 * <summary>
 *  Interface for the sport event query service.
 *  Defines the contract for the sport event query service.
 * </summary>
 */
public interface ISportEventQueryService
{
   Task<int> Handle(string location, string eventName, string sportType);
}