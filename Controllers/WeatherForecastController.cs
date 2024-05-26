using Microsoft.AspNetCore.Mvc;

namespace ProyectoAPI.Controllers;

[ApiController]
[Route("api/[controller]")] //Mapeo a nivel de controlador
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> listWeatherForecast = new List<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (listWeatherForecast == null || !listWeatherForecast.Any())
        {
            listWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("get/weatherforecast")] //Enrutamiento a nivel metodo
    //[Route("Get/weatherforecast2")] //Enrutamiento a nivel metodo
    //[Route("[action]")] //Este permite utilizar el nombre del metodo para accederlo.
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Retornando la lista de weatherforecast");
        return listWeatherForecast;
        /*return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();*/
    }

    //Metodo para adicionar
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        listWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        listWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
