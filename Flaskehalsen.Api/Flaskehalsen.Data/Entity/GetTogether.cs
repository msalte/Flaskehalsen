using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flaskehalsen.Data.Entity;

public class GetTogether : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateUtc { get; set; }

    public List<Person> Attendees { get; set; } = new();

    [ForeignKey("Club")] public Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}