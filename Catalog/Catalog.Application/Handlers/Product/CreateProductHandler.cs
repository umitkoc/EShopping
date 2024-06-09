using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Product;

public class CreateProductHandler:IRequestHandler<CreateProductCommand,ProductResponse>
{
    private readonly IProductRepo _repo;
    public CreateProductHandler(IProductRepo repo)
    {
        _repo = repo;
    }
    
    
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = Mapper.ProductMapper.Map<Core.Entities.Product>(request);
        if (productEntity is null)
        {
            throw new ApplicationException("Create new product error");
        }

        var product = await _repo.CreateProduct(productEntity);
        var productResponse = Mapper.ProductMapper.Map<ProductResponse>(product);
        return productResponse;
    }
}