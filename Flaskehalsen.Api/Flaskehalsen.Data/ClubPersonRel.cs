using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class ClubPersonRel
{
    [Key]
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid ClubId { get; set; }
    public DateTime SinceUtc { get; set; }
}