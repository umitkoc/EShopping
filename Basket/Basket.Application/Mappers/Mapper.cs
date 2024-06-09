using AutoMapper;

namespace Basket.Application.Mappers;

public class Mapper
{
    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config=new MapperConfiguration(cfg=>
        {
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MappingProfile>();
        });
        return config.CreateMapper();
    });


    public static IMapper CardMapper => Lazy.Value;
}