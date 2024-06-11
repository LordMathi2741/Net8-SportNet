using SportnetApi.Shared.Domain.Repositories;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SportnetApi.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}