using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flaskehalsen.Data.Entity;

public class GetTogether : IEntity
{
    [Key] public Guid Id { get; set; }
    public DateTime DateUtc { get; set; }

    public List<Person> Attendees { get; set; } = new();
    public List<Flask> Flasks { get; set; } = new();
    public List<FlaskScore> FlaskScores { get; set; } = new();

    [ForeignKey(nameof(Club))] public Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;

    [ForeignKey(nameof(Scale))] public Guid ScaleId { get; set; }
    public Scale Scale { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}