namespace LicApiTests.Authentication
{
    public class AuthRequestBody
    {
        public string Username { get; set; } 
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
