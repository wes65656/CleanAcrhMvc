using AutoMapper;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Aplication.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}