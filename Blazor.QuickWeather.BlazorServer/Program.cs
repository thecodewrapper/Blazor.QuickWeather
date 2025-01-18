using Blazor.QuickWeather.BlazorServer.Components;
using Blazor.QuickWeather.Extensions;
using Serilog;
using System.Reflection;

namespace Blazor.QuickWeather.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Configuration
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddUserSecrets(Assembly.GetExecutingAssembly())
                    .AddEnvironmentVariables();

            builder.Services.AddHttpClient();
            builder.Services.AddQuickWeather(options =>
            {
                // Additional configuration if needed
            });

            builder.Services.AddOpenWeatherMap(options =>
            {
                options.CurrentWeatherApiKey = builder.Configuration["WeatherApiResources:OpenWeatherMap:CurrentWeatherApiKey"];
                options.OneCallApiKey = builder.Configuration["WeatherApiResources:OpenWeatherMap:OneCallApiKey"];
            });
            builder.Services.AddWeatherApi(options =>
            {
                options.ApiKey = builder.Configuration["WeatherApiResources:WeatherApi:ApiKey"];
            });

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(builder.Configuration)
                        .CreateLogger();
            builder.Logging.AddSerilog();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
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
