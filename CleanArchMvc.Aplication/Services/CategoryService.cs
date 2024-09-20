using AutoMapper;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Aplication.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Aplication.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService (ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var categoriesEntity =await _categoryRepository.GetCategories();
        return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
    }

    public async Task<CategoryDto> GetById(int? id)
    {
        var categoryEntity =await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task Add(CategoryDto categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoryEntity);
    }

    public async Task Update(CategoryDto categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Remove(categoryEntity);
    }
}