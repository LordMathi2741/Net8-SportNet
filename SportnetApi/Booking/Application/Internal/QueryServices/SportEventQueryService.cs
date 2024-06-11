using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Model.Queries;
using SportnetApi.Booking.Domain.Repositories;
using SportnetApi.Booking.Domain.Services;
using SportnetApi.Shared.Domain.Repositories;

namespace SportnetApi.Booking.Application.Internal.QueryServices;

public class SportEventQueryService(IUnitOfWork unitOfWork, ISportEventRepository sportEventRepository) : ISportEventQueryService
{
    public async Task<int> Handle(string location, string eventName, string sportType)
    {
        return await sportEventRepository.FindByLocationAndEventNameAndSportTypeAsync(location, eventName, sportType);
    }
}