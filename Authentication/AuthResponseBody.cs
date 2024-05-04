namespace LicApiTests.Authentication
{
    public class AuthResponseBody
    {
        public string token { get; set; } = default!;
        public string expiration { get; set; } = default!;
    }
}
