using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Core.Repositories;
using MediatR;
using Mapper = Catalog.Application.Mappers.Mapper;

namespace Catalog.Application.Handlers.Product;

public class RemoveProductsHandler:IRequestHandler<RemoveProductsCommand,bool>
{

    private readonly IProductRepo _product;
    public RemoveProductsHandler(IProductRepo product)
    {
        _product = product;
    }
    
    public async Task<bool> Handle(RemoveProductsCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _product.RemoveProducts();
        var response = Mapper.ProductMapper.Map<bool>(productEntity);
        return response;
    }
}