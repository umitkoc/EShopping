using AutoMapper;
using Basket.Core.Entities;

namespace Basket.Application.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ShoppingCard,Responses.ShoppingCardResponse>().ReverseMap();
        CreateMap<ShoppingCardItem,Responses.ShoppingCardItemResponse>().ReverseMap();
    }
}