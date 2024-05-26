using AutoMapper;
using ProyectoAPI.Dto;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Dto.Responses;
using ProyectoAPI.Models;

namespace ProyectoAPI.Profiles;

public class CategoriaProfile : Profile
{
    
    public CategoriaProfile()
    {
        CreateMap<Categoria, Categoria2DTO>();

        CreateMap<CategoriaCreate, Categoria>()
            .ForMember(
                dest => dest.CategoriaId, 
                src => src.MapFrom(x => Guid.NewGuid()));

    }

}