
using System.Text.Json.Serialization;

namespace WeatherService.Services.WeatherStack;

public class Location
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("timezone_id")]
    public string TimezoneId { get; set; }

}
