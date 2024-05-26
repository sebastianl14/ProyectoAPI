using ProyectoAPI.Models;

namespace ProyectoAPI.Dto.Request;

public class TareaCreate
{
    public Guid CategoriaId {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
}