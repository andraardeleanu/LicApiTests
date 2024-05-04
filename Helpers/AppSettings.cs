namespace BTPopriri.GarnishmentManagement.Api.E2ETests.Core
{
    public class AppSettings
    {
        public static string? LicApiUrl => Settings.Instance.CustomSettings?.TestSettings?.LicApiUrl;
        public static string? ConnectionString => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.DatabaseConnection?.ConnectionString);
        public static string? ApiToken => Settings.Instance.CustomSettings?.EndpointsSettings?.ApiToken;
        public static string? Username => Settings.Instance.CustomSettings?.Credentials?.Username;
        public static string? Password => Settings.Instance.CustomSettings?.Credentials?.Password;
        public static string? AuthTokenUsername => Settings.Instance.CustomSettings?.Credentials?.AuthTokenUsername;
        public static string? AuthTokenPassword => Settings.Instance.CustomSettings?.Credentials?.AuthTokenPassword;
    }
}
