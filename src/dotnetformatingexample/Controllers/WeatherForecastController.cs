using Microsoft.AspNetCore.Mvc;

namespace dotnetformatingexample.Controllers;

[ApiController]
[Route("api/v1/weather-forecasts")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = nameof(GetWeatherForecast))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<WeatherForecast>> GetWeatherForecast()
    {
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        _logger.LogInformation("Generated {ForecastCount} weather forecast records.", forecast.Length);

        return Ok(forecast);
    }
}
