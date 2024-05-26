using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Models;

namespace ProyectoAPI.Services;

public class TareaService : ITareaService
{
    TareasContext context;
    private readonly IMapper mapper;

    public TareaService(TareasContext dbContext, IMapper iMapper)
    {
        context = dbContext;
        mapper = iMapper;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas.Include(p=> p.Categoria);
    }

    public Ejecucion Save(TareaCreate tareaCreate)
    {
        if (context.Categorias.Find(tareaCreate.CategoriaId) == null)
        {
            return Ejecucion.LlaveForaneaNoEncontra;
        }

        Tarea tarea = mapper.Map<Tarea>(tareaCreate);
        context.Add(tarea);
        context.SaveChanges();
        return Ejecucion.Finalizada;
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();

    Ejecucion Save(TareaCreate tareaCreate);
}

public enum Ejecucion
{
    Finalizada,
    LlaveForaneaNoEncontra

}