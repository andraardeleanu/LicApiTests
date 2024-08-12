namespace LicApiTests.Authentication
{
    public class AuthResponseBody
    {
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; } = default!;
    }
}
