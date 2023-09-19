using Microsoft.EntityFrameworkCore;
using WeatherService.Data.Entities;

namespace WeatherService.Data.Repositories;

public class CountryRepository
{
    private readonly ApplicationDbContext _ctx;

    public CountryRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Country> GetCountryByNameAsync(string name)
    {
        return await _ctx.Countries.Where(c => c.Name == name).FirstOrDefaultAsync();
    }

    public async Task<Country> CreateAsync(string name)
    {
        var country = new Country() { Name = name };

        _ctx.Countries.Add(country);
        await _ctx.SaveChangesAsync();

        return country;
    }
}
