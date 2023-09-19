using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeatherService.Data;
using WeatherService.Data.Repositories;
using WeatherService.Services.WeatherStack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

#region Our configurations

// Quando encontrar um tipo IWeatherService no construtor,
// irá ser criado um objeto do tipo que está identificado "depois da vírgula"
builder.Services.AddScoped<IWeatherService, WeatherStackService>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<CityRepository>();
// AddTransient -> Criar um novo objeto sempre que seja solicitado
// AddScoped    -> Cria um único objeto por request
// AddSingleton -> Cria um único objeto enquanto a app estiver a correr


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
