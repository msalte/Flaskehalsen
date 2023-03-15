using System.Reflection;
using Flaskehalsen.Service.Dto;
using Mapster;

namespace Flaskehalsen.Service.Configuration;

public static class MapsterConfiguration
{
    public static void AddMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var applicationAssembly = typeof(DtoBase<,>).Assembly;
        typeAdapterConfig.Scan(applicationAssembly);
    }
}