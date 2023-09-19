using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using WeatherService.Services;
using WeatherService.Services.WeatherStack;

namespace WeatherService.Pages
{
    public class OlaModel : PageModel
    {
        private readonly ILogger<OlaModel> _logger;
        private readonly IWeatherService _service;

        public IWeather MyWeatherData { get; set; }
        public OlaModel(ILogger<OlaModel> logger)
        {
            _logger = logger;
            // _service = new StandardWeatherService();
            _service = new WeatherStackService();
        }
        public async Task OnGetAsync(string? city)
        {
            city = city ?? "Lisboa";
            MyWeatherData = await _service.GetWeatherAsync(city);
        }
    }
}