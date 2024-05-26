using ProyectoAPI.Models;

namespace ProyectoAPI.Dto;

public class CategoriaDTO
{
    public Guid CategoriaId {get;set;}
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}

    public List<TareaDTO> Tareas {get;set;}
}

public class TareaDTO
{
    public Guid TareaId {get;set;}
    public Guid CategoriaId {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}    

}