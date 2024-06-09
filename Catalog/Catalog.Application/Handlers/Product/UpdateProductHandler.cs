using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Product;

public class UpdateProductHandler:IRequestHandler<UpdateProductCommand,bool>
{
    private readonly IProductRepo _product;
    public UpdateProductHandler(IProductRepo product)
    {
        _product = product;
    }
    
    
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _product.UpdateProduct(new Core.Entities.Product()
        {
            Id = request.Id,
            Description = request.Description,
            ProductType = request.ProductType,
            Name = request.Name,
            Price = request.Price,
            Summary = request.Summary,
            ImageUrl = request.ImageUrl,
            ProductBrands = request.ProductBrands
        });
        var response = Mapper.ProductMapper.Map<bool>(productEntity);
        return response;
    }
}