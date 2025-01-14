using Blazor.QuickWeather.BlazorServer.Components;
using Blazor.QuickWeather.Extensions;

namespace Blazor.QuickWeather.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddQuickWeather(options =>
            {
                options.AddApiResource("WeatherApi1", "https://api.weather.com/v1/forecast", "your-weather-api-key-1")
                       .AddApiResource("WeatherApi2", "https://api.openweathermap.org/data/2.5/weather", "your-weather-api-key-2")
                       .SetDefaultApiResource("WeatherApi1");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
