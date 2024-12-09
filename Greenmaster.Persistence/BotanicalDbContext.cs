using Greenmaster.Domain.Common;
using Greenmaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Persistence;

public class BotanicalDbContext(DbContextOptions<BotanicalDbContext> options) : DbContext(options)
{
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Bloom> Blooms { get; set; }
    public DbSet<SymbioticRelation> SymbioticRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BotanicalDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedAt = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}