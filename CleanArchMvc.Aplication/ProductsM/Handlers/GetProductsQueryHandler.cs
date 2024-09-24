
using CleanArchMvc.Aplication.ProductsM.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Aplication.ProductsM.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;
    
    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.Id);
    }
}