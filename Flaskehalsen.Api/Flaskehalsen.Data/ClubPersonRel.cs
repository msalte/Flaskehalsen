using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class ClubPersonRel : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid ClubId { get; set; }
    public DateTime SinceUtc { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}