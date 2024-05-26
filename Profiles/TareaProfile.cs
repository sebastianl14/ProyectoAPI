using AutoMapper;
using ProyectoAPI.Dto;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Models;

namespace ProyectoAPI.Profiles;

public class TareaProfile : Profile
{
    public TareaProfile()
    {
        CreateMap<Tarea, TareaDTO>();

        CreateMap<TareaCreate, Tarea>()
            .ForMember(
                dest => dest.TareaId, 
                src => src.MapFrom(x => Guid.NewGuid()))
            .ForMember(
                dest => dest.FechaCreacion,
                src => src.MapFrom(x => DateTime.Now));
    }
}