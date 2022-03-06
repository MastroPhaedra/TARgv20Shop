using Microsoft.AspNetCore.Mvc;
using Targv20Shop.Core.Dtos.Weather;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Models.Weather;

namespace Targv20Shop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity vm = new SearchCity();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            //vaja teha andmete edastamine service classi ja sealt andmete k'tte saamine l'bi dto classi.
            var dto = _weatherForecastServices.GetForecast(city);

            City model = new City();

            //Name
            model.Name = dto.Name;

            //Main
            model.Temp = dto.Main.Temp;
            model.Pressure = dto.Main.Pressure;
            model.Humidity = dto.Main.Humidity;
            model.TempFeelsLike = dto.Main.Feels_Like;

            //Coord
            //dto.Coord.Lon = weatherInfo.Coord.Lon;
            //dto.Coord.Lat = weatherInfo.Coord.Lat;

            //Weather
            //model.Weather = dto.Weather[0].Id; //Only for Integer
            model.Weather = dto.Weather[0].Main;
            //dto.Weather[0].Description = weatherInfo.Weather[0].Description;
            //dto.Weather[0].Icon = weatherInfo.Weather[0].Icon;

            //Base
            //dto.Base = weatherInfo.Base;

            //Visibility
            //dto.Visibility = weatherInfo.Visibility;

            //Wind
            model.Wind = dto.Wind.Speed;

            //Clouds
            //dto.Clouds.All = weatherInfo.Clouds.All;

            //Dt
            //dto.Dt = weatherInfo.Dt;

            //Sys
            //dto.Sys.Type = weatherInfo.Sys.Type;
            //dto.Sys.Id = weatherInfo.Sys.Id;
            //dto.Sys.Message = weatherInfo.Sys.Message;
            //dto.Sys.Country = weatherInfo.Sys.Country;
            //dto.Sys.Sunrise = weatherInfo.Sys.Sunrise;
            //dto.Sys.Sunshine = weatherInfo.Sys.Sunshine;

            //Timezone
            //dto.Timezone = weatherInfo.Timezone;

            //Id
            //dto.Id = weatherInfo.Id;

            //Name
            //dto.Name = weatherInfo.Name;

            //Cod
            //dto.Cod = weatherInfo.Cod;

            return View(model);
        }
    }
}