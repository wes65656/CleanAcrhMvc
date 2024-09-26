using AutoMapper;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Aplication.ProductsM.Commands;

namespace CleanArchMvc.Aplication.Mappings;

public class DtoToCommandMappingProfile : Profile
{
    public DtoToCommandMappingProfile()
    {
        CreateMap<ProductDto, ProductCreateCommand>();
        CreateMap<ProductDto, ProductUpdateCommand>();
    }
}