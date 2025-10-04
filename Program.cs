using Serilog;

namespace Optimizely002;

public class Program
{
    public static IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration).WriteTo.Console().CreateLogger();

        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
