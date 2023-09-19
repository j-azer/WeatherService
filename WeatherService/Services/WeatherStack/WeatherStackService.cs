using RestSharp;
using System.Globalization;
using WeatherService.Data.Repositories;
using WeatherService.Services.Models;

namespace WeatherService.Services.WeatherStack;

public class WeatherStackService : IWeatherService
{
    private static string url = "http://api.weatherstack.com/current?access_key=062187fa6c30a3b77addda95b52dcf67&query=";

    public async Task<IWeather> GetWeatherAsync(string city)
    {
        var endpoint = url + city;

        var client = new RestClient(endpoint);
        var request = new RestRequest("", Method.Get);
        RestResponse<Root> response = await client.ExecuteAsync<Root>(request);

        var apiData = response.Data;

        return new WeatherData()
        {
            Country = apiData.Location.Country,
            City = city,
            Icon = apiData.Current.Icons.FirstOrDefault(),
            Temperature = apiData.Current.Temperature,            
            Lat = double.Parse(apiData.Location.Lat, CultureInfo.InvariantCulture),
            Long = double.Parse(apiData.Location.Lon, CultureInfo.InvariantCulture),            
            LastUpdated = DateTime.UtcNow
        };
    }

   
}
