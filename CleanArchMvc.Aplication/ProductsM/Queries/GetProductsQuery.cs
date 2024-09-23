using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Aplication.ProductsM.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
    
}