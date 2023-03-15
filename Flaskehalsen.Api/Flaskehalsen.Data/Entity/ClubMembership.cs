namespace Flaskehalsen.Data.Entity;

public class ClubMembership : IEntity
{
    public Guid PersonId { get; set; }
    public Guid ClubId { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}