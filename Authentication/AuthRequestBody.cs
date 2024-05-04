namespace LicApiTests.Authentication
{
    public class AuthRequestBody
    {
        public string username { get; set; } = default!;
        public string password { get; set; } = default!;
        public string rememberMe { get; set; }
    }
}
