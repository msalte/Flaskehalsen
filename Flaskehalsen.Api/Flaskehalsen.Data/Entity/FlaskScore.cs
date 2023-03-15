using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flaskehalsen.Data.Entity;

public class FlaskScore : IEntity
{
    [Key] public Guid Id { get; set; }

    [ForeignKey(nameof(Entity.Flask))] public Guid FlaskId { get; set; }
    public Flask Flask { get; set; }

    [ForeignKey(nameof(Person))] public Guid PersonId { get; set; }
    public Person Person { get; set; }

    [ForeignKey(nameof(Entity.GetTogether))]
    public Guid GetTogetherId { get; set; }

    public GetTogether GetTogether { get; set; }

    public int ScoreScaleIndex { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}