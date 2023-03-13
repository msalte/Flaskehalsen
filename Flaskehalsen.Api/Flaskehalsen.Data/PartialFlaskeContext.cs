using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Data;

public partial class FlaskeContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var changeSet = ChangeTracker.Entries<IEntity>();

        foreach (var change in changeSet)
        {
            if (change.State == EntityState.Added)
            {
                change.Entity.CreatedUtc = DateTime.UtcNow;
                change.Entity.UpdatedUtc = DateTime.UtcNow;
            }
            else if (change.State == EntityState.Modified)
            {
                change.Entity.UpdatedUtc = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}