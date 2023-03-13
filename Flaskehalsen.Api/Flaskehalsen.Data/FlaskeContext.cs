using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Data;

public class FlaskeContext : DbContext
{
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<ClubPersonRel> ClubPersonRels { get; set; }

    public FlaskeContext(DbContextOptions<FlaskeContext> options) : base(options)
    {
        
    }
}