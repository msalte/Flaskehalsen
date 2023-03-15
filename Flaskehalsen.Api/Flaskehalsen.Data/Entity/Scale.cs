using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data.Entity;

public class Scale : IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string ValueJsonArray { get; set; }
    
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}