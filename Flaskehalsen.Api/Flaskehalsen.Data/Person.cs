using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class Person : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}