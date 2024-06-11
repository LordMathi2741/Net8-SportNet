using Microsoft.EntityFrameworkCore;
using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Repositories;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SportnetApi.Booking.Infrastructure.Persistence.EFC.Repositories;

public class SportEventRepository(AppDbContext context) : BaseRepository<SportEvent>(context), ISportEventRepository
{
    public async Task<int> FindByLocationAndEventNameAndSportTypeAsync(string location, string eventName, string sportType)
    {
        return await context.Set<SportEvent>().CountAsync(sportEvent =>
            sportEvent.Location == location && sportEvent.EventName == eventName && sportEvent.SportType == sportType);
    }
}