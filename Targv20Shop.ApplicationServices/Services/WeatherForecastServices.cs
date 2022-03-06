using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos.Weather;
using Targv20Shop.Core.ServiceInterface;


namespace Targv20Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResponseDto> WeatherDetail(WeatherResponseDto dto)
        {
            //string apikey = "nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y";
            //var Location = "Tallinn";
            // connection string
           var url = $"http://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&cnt=1&APPID=10802a322cab84354d59fb3e37ee800e";

           using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherResponseDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherResponseDto>(json);
                
                //Main
                dto.Main.Temp = weatherInfo.Main.Temp;
                dto.Main.Pressure = weatherInfo.Main.Pressure;
                dto.Main.Humidity = weatherInfo.Main.Humidity;
                dto.Main.Temp_Min = weatherInfo.Main.Temp_Min;
                dto.Main.Temp_Max = weatherInfo.Main.Temp_Max;
                dto.Main.Feels_Like = weatherInfo.Main.Feels_Like;

                //Coord
                dto.Coord.Lon = weatherInfo.Coord.Lon;
                dto.Coord.Lat = weatherInfo.Coord.Lat;

                //Weather
                dto.Weather[0].Id = weatherInfo.Weather[0].Id; //Only for Integer
                dto.Weather[0].Main = weatherInfo.Weather[0].Main;
                dto.Weather[0].Description = weatherInfo.Weather[0].Description;
                dto.Weather[0].Icon = weatherInfo.Weather[0].Icon;

                //Base
                dto.Base = weatherInfo.Base;

                //Visibility
                dto.Visibility = weatherInfo.Visibility;

                //Wind
                dto.Wind.Speed = weatherInfo.Wind.Speed;
                dto.Wind.Deg = weatherInfo.Wind.Deg;

                //Clouds
                dto.Clouds.All = weatherInfo.Clouds.All;

                //Dt
                dto.Dt = weatherInfo.Dt;

                //Sys
                dto.Sys.Type = weatherInfo.Sys.Type;
                dto.Sys.Id = weatherInfo.Sys.Id;
                dto.Sys.Message = weatherInfo.Sys.Message;
                dto.Sys.Country = weatherInfo.Sys.Country;
                dto.Sys.Sunrise = weatherInfo.Sys.Sunrise;
                dto.Sys.Sunshine = weatherInfo.Sys.Sunshine;

                //Timezone
                dto.Timezone = weatherInfo.Timezone;

                //Id
                dto.Id = weatherInfo.Id;

                //Name
                dto.Name = weatherInfo.Name;

                //Cod
                dto.Cod = weatherInfo.Cod;


                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }

        WeatherResponseDto IWeatherForecastServices.GetForecast(string City)
        {
            //string appKey = "nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y";
            // Connection String
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&cnt=1&APPID=10802a322cab84354d59fb3e37ee800e");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponseDto>();
            }

            return null;
        }

        string IWeatherForecastServices.WeatherDetail(string City)
        {
            throw new System.NotImplementedException();
        }
    }
}