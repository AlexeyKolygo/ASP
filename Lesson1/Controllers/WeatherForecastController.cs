using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Net.HttpStatusCode;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherList _Weather;
        public WeatherForecastController(WeatherList Weather)
        {
            _Weather= Weather;
        }


        [HttpPost]
        public IActionResult Create([FromQuery] int temp,DateTime date)
        {
        WeatherForecast w = new WeatherForecast();

            w.Date = date;
            w.TemperatureC = temp;
            _Weather.Weather.Add(w);
            return Ok(w);
        }

        [HttpGet("get/{from}")]

        public IActionResult Read(DateTime from)
        {
            try
            {
                return (from t in _Weather.Weather where t.Date == @from select Ok(t)).FirstOrDefault();
            }
            catch
            {
                return StatusCode(408);
            }
        }

        [HttpGet("getall")]

            public IActionResult Read()
            {
            
                return Ok(_Weather.Weather);
            }

        [HttpDelete("{date}")]
            public IActionResult Delete(DateTime date)
            {
                for (int i = 0; i < _Weather.Weather.Count; i++)
                {
                    if (_Weather.Weather[i].Date == date)
                    {
                        _Weather.Weather.RemoveAt(i);
                        return Ok();
                    }
                }

                return StatusCode(404);
            }

            [HttpPut()]
            public IActionResult Update([FromQuery] DateTime date, [FromQuery] int newtemp)
            {
                for (int i = 0; i < _Weather.Weather.Count; i++)
                {
                    if (_Weather.Weather[i].Date == date)
                    {
                        _Weather.Weather[i].TemperatureC=newtemp;
                        return Ok($"Temp for {date} has been updated");
                    }
                }
                return StatusCode(404);
        }


    }
}
