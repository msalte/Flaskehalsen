using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class Person
{
    [Key]
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
}