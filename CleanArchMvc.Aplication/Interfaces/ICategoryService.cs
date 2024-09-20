using CleanArchMvc.Aplication.DTOs;

namespace CleanArchMvc.Aplication.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<CategoryDto> GetById(int? id);

    Task Add(CategoryDto categoryDto);
    Task Update(CategoryDto categoryDto);
    Task Remove(int? id);
}
