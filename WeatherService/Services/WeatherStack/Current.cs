using System.Text.Json.Serialization;

namespace WeatherService.Services.WeatherStack;

public class Current
{
    public double Temperature { get; set; }

    [JsonPropertyName("weather_icons")]
    public string[] Icons { get; set; }
}
