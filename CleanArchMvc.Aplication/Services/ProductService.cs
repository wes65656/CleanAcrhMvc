using System.Diagnostics;
using AutoMapper;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Aplication.Interfaces;
using CleanArchMvc.Aplication.ProductsM.Commands;
using CleanArchMvc.Aplication.ProductsM.Queries;
using MediatR;

namespace CleanArchMvc.Aplication.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper,IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var productsQuery = new GetProductsQuery();
        
        if (productsQuery is null)
        {
            throw new Exception($"Entity could not be loaded");
        }

        var result = await _mediator.Send(productsQuery);

        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<ProductDto> GetById(int? id)
    {
        Debug.Assert(id != null, nameof(id) + " != null");
        var productByIdQuery = new GetProductByIdQuery(id.Value);

        if (productByIdQuery is null)
            throw new Exception($"Entity could not be loaded");

        var result = await _mediator.Send(productByIdQuery);
        
        return _mapper.Map<ProductDto>(result);
    }
    
    
    public async Task Add(ProductDto productDto)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(productCreateCommand);
    }
    
    public async Task Update(ProductDto productDto)
     {
         var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto); 
         await _mediator.Send(productUpdateCommand);
     }
     
    public async Task Remove(int? id)
    {
        Debug.Assert(id != null, nameof(id) + " != null");
        var productRemoveCommand = new ProductRemoveCommand(id.Value);
        if (productRemoveCommand is null)
            throw new Exception($"Entity could not be loaded");

        await _mediator.Send(productRemoveCommand);
    }
}