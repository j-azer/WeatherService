using WeatherService.Data.Entities;

namespace WeatherService.Data.Repositories;

public class CityRepository
{
    private readonly ApplicationDbContext _ctx;

    public CityRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<City> CreateAsync(string name, double temperature, DateTime lastUpdated, int countryId)
    {
        var city = new City()
        {
            Name = name,
            Temperature = temperature,
            LastUpdated = lastUpdated,
            CountryId = countryId,
        };

        return await CreateAsync(city);
    }

    public async Task<City> CreateAsync(City city)
    {
        _ctx.Cities.Add(city);
        await _ctx.SaveChangesAsync();
        return city;
    }
}
