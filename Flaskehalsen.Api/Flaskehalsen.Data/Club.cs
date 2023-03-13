using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class Club
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}