using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data.Entity;

public class Flask : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Origin { get; set; }
    public decimal? Price { get; set; }
    public FlaskType Type { get; set; }

    public List<GetTogether> GetTogethers { get; set; }
    
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}