using MusicLibrary.Server;

//implemented but not used in the final project
namespace MusicLibrary.WebAPI.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}