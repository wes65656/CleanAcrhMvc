using AutoMapper;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Aplication.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Aplication.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _productRepository = productRepository ?? 
                             throw new ArgumentException(nameof(productRepository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var productEntity = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(productEntity);
    }

    public async Task<ProductDto> GetById(int? id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task<ProductDto> GetProductCategory(int? id)
    {
        var productEntity = await _productRepository.GetCategoryIdAsync(id);
        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task Add(ProductDto productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.CreateAsync(productEntity);
    }

    public async Task Update(ProductDto productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.UpdateAsync(productEntity);
    }

    public async Task Remove(int? id)
    {
        var productEntity = _productRepository.GetByIdAsync(id).Result;
        await _productRepository.RemoveAsync(productEntity);
    }
}