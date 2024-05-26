using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService tareaService)
    {
        this.tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] TareaCreate tareaCreate)
    {
        Ejecucion ejecucion = tareaService.Save(tareaCreate);
        if (ejecucion == Ejecucion.Finalizada)
        {
            return Ok("Se creó la tarea");
        } 
        else 
        {
            return NotFound($"La categría (CategoriaId='{tareaCreate.CategoriaId}') no existe, por lo cual la tarea no se puede crear, por favor verifique e intente nuevamente");
        }
    }

}