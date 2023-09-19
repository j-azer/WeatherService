public interface IWeatherService
{
    Task<IWeather> GetWeatherAsync(string city);
}