using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Dto;
using ProyectoAPI.Dto.Request;
using ProyectoAPI.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        this.categoriaService = categoriaService;
    }

    [HttpGet]
    public IEnumerable<Categoria> Get()
    {
        return categoriaService.Get();
    }

    [HttpGet]
    [Route("GetTareasXCategoria/{id}")]
    public IActionResult GetTareasXCategoria(Guid id)
    {
        return Ok(categoriaService.GetTareasXCategoria(id));
    }

    [HttpGet]
    [Route("Get2")]
    public IActionResult Get2()
    {
        return Ok(categoriaService.GetTareasXCategoria2());
    }

    [HttpGet]
    [Route("Get3")]
    public IActionResult Get3()
    {
        return Ok(categoriaService.GetTareasXCategoria3());
    }

    /// <summary>
    /// Este metodo nos devuelve las categorias paginas.
    /// </summary>
    /// <param name="categoriaPaginacionDTO"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetPaginado")]
    public async Task<List<Categoria>> GetPaginado([FromQuery]CategoriaPaginacionDTO categoriaPaginacionDTO)//esto a partir de ahora se le pedirá al usuario
    {
        return await categoriaService.GetPaginado(categoriaPaginacionDTO);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CategoriaCreate categoriaCreate)
    {
        categoriaService.Save(categoriaCreate);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }

}