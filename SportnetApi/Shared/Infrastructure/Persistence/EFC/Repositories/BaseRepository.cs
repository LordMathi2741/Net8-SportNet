using SportnetApi.Shared.Domain.Repositories;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SportnetApi.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try 
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
        
}