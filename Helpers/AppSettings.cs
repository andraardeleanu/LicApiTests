namespace BTPopriri.GarnishmentManagement.Api.E2ETests.Core
{
    public class AppSettings
    {
        public static string? LicApiUrl => Settings.Instance.CustomSettings?.TestSettings?.LicApiUrl;
        public static string? ConnectionString => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.DatabaseConnection?.ConnectionString!);
        public static string? UsernameAdmin => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.CredentialsAdmin?.Username!);
        public static string? PasswordAdmin => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.CredentialsAdmin?.Password!);
        public static string? UsernameCustomer => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.CredentialsCustomer?.Username!);
        public static string? PasswordCustomer => AesEncryptionService.Decrypt(Settings.Instance.CustomSettings?.CredentialsCustomer?.Password!);
    }
}
