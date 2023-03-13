namespace Flaskehalsen.Data;

public interface IEntity
{
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}