﻿using AutoMapper;

namespace Catalog.Application.Mappers;

public class Mapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config=new MapperConfiguration(cfg=>
        {
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<ProductMappingProfile>();
        });
        return config.CreateMapper();
    });


    public static IMapper ProductMapper => Lazy.Value;
}