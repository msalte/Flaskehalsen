namespace Flaskehalsen.Data.Entity;

public class GetTogetherFlasks : IEntity
{
    public Guid GetTogetherId { get; set; }
    public Guid FlaskId { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}