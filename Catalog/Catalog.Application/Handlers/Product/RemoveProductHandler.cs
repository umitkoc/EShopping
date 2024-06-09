using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Product;

public class RemoveProductHandler:IRequestHandler<RemoveProductCommand,bool>
{
    private readonly IProductRepo _product;
    public RemoveProductHandler(IProductRepo product)
    {
        _product = product;
    }
    
    
    public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _product.RemoveProduct(request.Id!);
        var productResponse = Mapper.ProductMapper.Map<bool>(productEntity);
        return productResponse;

    }
}