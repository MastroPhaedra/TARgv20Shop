using Targv20Shop.Core.Dtos.Weather;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        string WeatherDetail(string City);
        WeatherResponseDto GetForecast(string city);
    }
}