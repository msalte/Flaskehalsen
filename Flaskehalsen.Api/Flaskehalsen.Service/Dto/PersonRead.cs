using Flaskehalsen.Data.Entity;

namespace Flaskehalsen.Service.Dto;

public class PersonRead : DtoBase<PersonRead, Person>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<ClubRead> Clubs { get; set; }

    public override void AddCustomMappings()
    {
        SetCustomMappings().Map(dest => dest.DisplayName, src => src.Name);
        SetCustomMappingsInverse().Map(dest => dest.Name, src => src.DisplayName);
    }
}