using Microsoft.Extensions.Configuration;

namespace BTPopriri.GarnishmentManagement.Api.E2ETests.Core
{
    public sealed class Settings
    {
        private static readonly Lazy<Settings> lazy = new Lazy<Settings>(() => new Settings());

        public static Settings Instance { get { return lazy.Value; } }

        public CustomSettings? CustomSettings { get; set; }

        private Settings()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Loading configuration for environment: {environmentName}");

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false)
                .AddJsonFile($"appSettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            CustomSettings = configuration.Get<CustomSettings>();
        }
    }

    public class CustomSettings
    {
        public TestSettings? TestSettings { get; set; }
        public EndpointsSettings? EndpointsSettings { get; set; }
        public Credentials? Credentials { get; set; }
        public DatabaseConnection? DatabaseConnection { get; set; }
    }

    public class TestSettings
    {
        public string? LicApiUrl { get; set; }
    }

    public class EndpointsSettings
    {
        public string? ApiToken { get; set; }
    }

    public class Credentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? AuthTokenUsername { get; set; }
        public string? AuthTokenPassword { get; set; }
    }

    public class DatabaseConnection
    {
        public string? ConnectionString { get; set; }
    }
}
