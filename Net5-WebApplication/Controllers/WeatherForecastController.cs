using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Net5_WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private static readonly string[] Cities = new[]
        {
            "İstanbul", "Bursa", "Çankırı", "Konya", "Ardahan", "Ordu", "Giresun", "Adana", "Sivas", "İzmir"
        };

        [HttpGet("getforecast/{id}")]
        public IEnumerable<WeatherForecast> GetForecast(int id)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            var rng = new Random();
            int i = 0;
            while (i < 30)
            {
                weatherForecasts.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    City = Cities[id]
                });
                i++;
            }
            return weatherForecasts;
        }
    }
}
