using Flaskehalsen.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Data;

public partial class FlaskeContext : DbContext
{
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<ClubMembership> ClubMemberships { get; set; }
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
        modelBuilder.Entity<Flask>().HasQueryFilter(f => !f.IsDeleted).Property(f => f.Price).HasPrecision(6, 4);
        modelBuilder.Entity<FlaskScore>().HasQueryFilter(fs => !fs.IsDeleted);
        modelBuilder.Entity<Scale>().HasQueryFilter(s => !s.IsDeleted);

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

        modelBuilder.Entity<GetTogether>()
            .HasMany(gt => gt.Flasks)
            .WithMany(f => f.GetTogethers)
            .UsingEntity<GetTogetherFlasks>()
            .HasQueryFilter(rel => !rel.IsDeleted);

        modelBuilder.Entity<GetTogether>()
            .HasOne(gt => gt.Scale)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}