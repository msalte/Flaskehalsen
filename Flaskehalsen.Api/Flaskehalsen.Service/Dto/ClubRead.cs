using Flaskehalsen.Data.Entity;

namespace Flaskehalsen.Service.Dto;

public class ClubRead : DtoBase<ClubRead, Club>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}