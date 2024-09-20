using CleanArchMvc.Aplication.DTOs;

namespace CleanArchMvc.Aplication.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetById(int? id);
    Task<ProductDto> GetProductCategory(int? id);
    
    Task Add (ProductDto productDto);
    Task Update (ProductDto productDto);
    Task Remove (int? id);
}