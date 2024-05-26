
using ProyectoAPI.Models;

namespace ProyectoAPI.Dto.Responses;

public class Categoria2DTO
{
    public Guid CategoriaId {get;set;}
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}

    public ICollection<TareaDTO> Tareas {get;set;}
}