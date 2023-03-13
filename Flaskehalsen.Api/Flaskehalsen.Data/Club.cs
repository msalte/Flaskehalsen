﻿using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data;

public class Club : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}