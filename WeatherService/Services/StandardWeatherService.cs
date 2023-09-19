using WeatherService.Services.Models;

namespace WeatherService.Services;

public class StandardWeatherService : IWeatherService
{

    public async Task<IWeather> GetWeatherAsync(string city)
    {
        Random rand= new Random();
        string[] icons = new string[] {"Sol", "Chuva", "Nublado"};
        int index = rand.Next(icons.Length);

        return new WeatherData()
        { 
            Country = "Portugal",
            City= city,            
            Icon = icons[index],
            Lat = Random.Shared.NextDouble()*100,
            Long = Random.Shared.NextDouble()*100,
            Temperature = Random.Shared.Next(5, 25),
            LastUpdated = DateTime.Now,
        };
    }   
}


