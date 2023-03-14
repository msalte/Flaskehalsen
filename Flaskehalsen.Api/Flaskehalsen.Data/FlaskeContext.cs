using Flaskehalsen.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Data;

public partial class FlaskeContext : DbContext
{
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<ClubMembership> ClubPersonRels { get; set; }
    public DbSet<GetTogether> GetTogethers { get; set; }

    public FlaskeContext(DbContextOptions<FlaskeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Club>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<GetTogether>().HasQueryFilter(gt => !gt.IsDeleted);
        modelBuilder.Entity<ClubInvitation>().HasQueryFilter(ci => !ci.IsDeleted);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Clubs)
            .WithMany(c => c.Members)
            .UsingEntity<ClubMembership>()
            .HasQueryFilter(rel => !rel.IsDeleted);
        
        modelBuilder.Entity<Person>()
            .HasMany(p => p.GetTogethers)
            .WithMany(c => c.Attendees)
            .UsingEntity<GetTogetherAttendance>()
            .HasQueryFilter(rel => !rel.IsDeleted);
        
        base.OnModelCreating(modelBuilder);
    }
}