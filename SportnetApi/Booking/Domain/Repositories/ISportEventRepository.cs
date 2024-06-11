using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Shared.Domain.Repositories;

namespace SportnetApi.Booking.Domain.Repositories;

/**
 * <summary>
 * Defines the contract for the SportEvent repository.
 * </summary>
 */

public interface ISportEventRepository : IBaseRepository<SportEvent>
{

 Task<int> FindByLocationAndEventNameAndSportTypeAsync(string location, string eventName, string sportType);
}