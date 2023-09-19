using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherService.Data;
using WeatherService.Data.Entities;

namespace WeatherService.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService.Data.ApplicationDbContext _context;

        public IndexModel(WeatherService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cities != null)
            {
                City = await _context.Cities
                .Include(c => c.Country).ToListAsync();
            }
        }
    }
}
