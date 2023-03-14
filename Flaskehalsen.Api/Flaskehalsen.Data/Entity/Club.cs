using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data.Entity;

public class Club : IEntity
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Person> Members { get; set; } = new();
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}