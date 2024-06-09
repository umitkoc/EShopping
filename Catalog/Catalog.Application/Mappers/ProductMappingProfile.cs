using AutoMapper;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Commands.Product;
using Catalog.Application.Commands.Type;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Application.Mappers;
public class ProductMappingProfile:Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product,ProductResponse>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Pagination<Product>, Pagination<ProductResponse>>().ReverseMap();
        
        CreateMap<ProductBrand,ProductBrandResponse>().ReverseMap();
        CreateMap<ProductBrand, CreateBrandCommand>().ReverseMap();
        CreateMap<ProductBrand, UpdateBrandCommand>().ReverseMap();
        
        CreateMap<ProductType,ProductTypeResponse>().ReverseMap();
        CreateMap<ProductType, CreateTypeCommand>().ReverseMap();
        CreateMap<ProductType, UpdateTypeCommand>().ReverseMap();
    }
}