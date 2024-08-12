namespace LicApiTests.Models.Responses
{
    public class LoggedInResponse
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List <CompanyResponse> Company { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
