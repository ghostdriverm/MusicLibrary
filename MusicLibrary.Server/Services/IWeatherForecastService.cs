using MusicLibrary.Server;

namespace MusicLibrary.WebAPI.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}