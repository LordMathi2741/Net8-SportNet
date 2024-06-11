using Microsoft.EntityFrameworkCore;
using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SportEvent> SportEvents { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new InvalidOperationException("No database provider has been configured for this context.");
        }
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SportEvent>().ToTable("sportevents");
        modelBuilder.Entity<SportEvent>().HasKey(sportEvent => sportEvent.Id);
        modelBuilder.Entity<SportEvent>().Property(sportEvent => sportEvent.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<SportEvent>().Property(sportEvent => sportEvent.EventName).IsRequired();
        modelBuilder.Entity<SportEvent>().Property(sportEvent => sportEvent.SportType).IsRequired();
        modelBuilder.Entity<SportEvent>().Property(sportEvent => sportEvent.Capacity).IsRequired();
        modelBuilder.Entity<SportEvent>().OwnsOne(organizerId => organizerId.OrganizerIdValue, oi =>
        {
            oi.WithOwner().HasForeignKey("Id");
            oi.Property(oid => oid.OrganizerIdValue).HasColumnName("OrganizerId");
        });
        modelBuilder.Entity<SportEvent>().Property(sportEvent => sportEvent.Location).IsRequired();
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}