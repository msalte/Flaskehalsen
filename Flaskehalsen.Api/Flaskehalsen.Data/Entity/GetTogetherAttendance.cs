namespace Flaskehalsen.Data.Entity;

public class GetTogetherAttendance : IEntity
{
    public Guid PersonId { get; set; }
    public Guid GetTogetherId { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}