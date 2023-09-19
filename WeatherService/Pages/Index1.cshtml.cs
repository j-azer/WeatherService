using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherService.Data;
using WeatherService.Data.Entities;
using WeatherService.Data.Repositories;
using WeatherService.Services;
using WeatherService.Services.WeatherStack;

namespace WeatherService.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherService _service;
        private readonly CountryRepository _countryRepository;
        private readonly CityRepository _cityRepository;
        private readonly ApplicationDbContext _ctx;

        public int NumDays { get; set; } = 100;
        public IWeather MyWeatherData { get; set; }


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext ctx, 
            IWeatherService weatherService, CountryRepository countryRepository, CityRepository cityRepository)
        {
            //_service = new StandardWeatherService();
            //_service = new WeatherStackService();
            _logger = logger;
            _ctx = ctx;
            _service = weatherService;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }


        // Método que é chamado automaticamente quando a página é chamada
        public async Task OnGetAsync(string? city)
        {
            Random rand = new Random();
            string[] cities = new string[] { "Lisboa", "Rio de Janeiro", "Madrid" };
            int index = rand.Next(cities.Length);

            if (city == null)
                city = cities[index];

            MyWeatherData = await _service.GetWeatherAsync(city);

            
            var country = await _countryRepository.GetCountryByNameAsync(MyWeatherData.Country)
            ?? await _countryRepository.CreateAsync(MyWeatherData.Country);

            await _cityRepository.CreateAsync(MyWeatherData.City, MyWeatherData.Temperature,
                MyWeatherData.LastUpdated, country.Id);

            // Ter uma instância de DbContext
            // Adicionar a nova entidade à coleção correspondente (no DbContext)
            // Gravar alterações

            //// Se country não existir...
            //if (country == null)
            //{
            //    country = await _countryRepository.CreateAsync(MyWeatherData.Country)
            //}

            //var cityModel = new City()
            //{
            //    Name = MyWeatherData.City,
            //    Temperature = MyWeatherData.Temperature,
            //    LastUpdated = MyWeatherData.LastUpdated,
            //    CountryId = country.Id,
            //};

            //await _cityRepository.CreateAsync(cityModel);
        }
    }
}