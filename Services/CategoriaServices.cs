using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Dto;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Dto.Responses;
using ProyectoAPI.Models;
using ProyectoAPI.Utils;

namespace ProyectoAPI.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;
    private readonly IMapper mapper;

    public CategoriaService(TareasContext dbContext, IMapper iMapper)
    {
        context = dbContext;
        mapper = iMapper;
    }

    public IEnumerable<Categoria> Get()
    {   
        var categorias = context.Categorias;
        return categorias;
    }

    public CategoriaDTO GetTareasXCategoria(Guid id)
    {   
        CategoriaDTO categoriaDTO = new CategoriaDTO();

        Categoria categoria = context.Categorias.Find(id);
        if (categoria != null)
        {
            categoriaDTO.CategoriaId = categoria.CategoriaId;
            categoriaDTO.Nombre = categoria.Nombre;
            categoriaDTO.Descripcion = categoria.Descripcion;
            categoriaDTO.Peso = categoria.Peso;

            categoriaDTO.Tareas = new List<TareaDTO>();

            
            foreach (var tarea in context.Tareas.Where(p=> p.CategoriaId == categoria.CategoriaId))
            {
                TareaDTO tareaDTO = new TareaDTO() {
                    TareaId = tarea.TareaId,
                    Titulo = tarea.Titulo,
                    CategoriaId = tarea.CategoriaId
                };
                categoriaDTO.Tareas.Add(tareaDTO);
            }
        }

        return categoriaDTO;
        /*
        categoria.Tareas.Add (tareas);
        
        var categorias_productos = (from categorias in context.Categorias
             join tareas in context.Tareas on categorias.CategoriaId equals tareas.CategoriaId
                select new
                {
                    categorias.CategoriaId,
                    categorias.Nombre,
                    categorias.Descripcion,
                    categorias.Peso
                }).ToList();

        return categorias_productos;
        */

        /*
        var productosXCategoria = from productos in contexto.Producto
            group productos by productos.CategoriaId into p
            select p).ToList()
        
        var tareasXCategoria = (from productos in context.Producto
            group productos by productos.CategoriaId into p
            select p).ToList();
        
        return tareaXCategoria;

        return context.Categorias;*/
    }

    public List<CategoriaDTO> GetTareasXCategoria2()
    {   
        List<CategoriaDTO> listaCategorias = new List<CategoriaDTO>();
        
        var categorias = context.Categorias.Include(p => p.Tareas);
        foreach (var categoria in categorias)
        {
            CategoriaDTO categoriaDTO = new CategoriaDTO() {
                CategoriaId = categoria.CategoriaId,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Peso = categoria.Peso,
                Tareas = new List<TareaDTO>()
            };

            foreach (var tarea in categoria.Tareas)
            {
                TareaDTO tareaDTO = new TareaDTO() {
                    TareaId = tarea.TareaId,
                    Titulo = tarea.Titulo,
                    CategoriaId = tarea.CategoriaId
                };
                categoriaDTO.Tareas.Add(tareaDTO);
            }

            listaCategorias.Add(categoriaDTO);
        }
        return listaCategorias;
    }

    public List<Categoria2DTO> GetTareasXCategoria3()
    {   
        //List<CategoriaDTO> listaCategorias = new List<CategoriaDTO>();
        var categorias = context.Categorias.Include(p => p.Tareas);
        var listaCategorias = mapper.Map<List<Categoria2DTO>>(categorias);
        return listaCategorias;
    }


    public async Task<List<Categoria>> GetPaginado(CategoriaPaginacionDTO categoriaPaginacionDTO)
    {
        //Aplicando paginación
        var queryable = context.Categorias
            .Where(p=> p.Nombre.ToUpper().Contains(categoriaPaginacionDTO.Nombre.ToUpper()))
            .AsQueryable();
        //await HttpContext.InsertPaginationHeader(queryable);
 
        var clientes = await queryable.OrderBy(x => x.CategoriaId).Paginate(categoriaPaginacionDTO).ToListAsync();//es recomendable ordenar cuando se pagina
        return clientes;
    }

    public async Task Save(CategoriaCreate categoriaCreate)
    {
        var categoria = mapper.Map<Categoria>(categoriaCreate);
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoria.Descripcion = categoria.Descripcion;
            categoria.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            context.Categorias.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();

    CategoriaDTO GetTareasXCategoria(Guid id);

    List<CategoriaDTO> GetTareasXCategoria2();

    List<Categoria2DTO> GetTareasXCategoria3();

    Task<List<Categoria>> GetPaginado(CategoriaPaginacionDTO categoriaPaginacionDTO);

    Task Save(CategoriaCreate categoriaCreate);

    Task Update(Guid id, Categoria categoria);

    Task Delete(Guid id);
}