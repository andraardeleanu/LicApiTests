namespace LicApiTests.Models.Responses
{
    public class GetUserByUsernameResponse
    {
        public string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required IList<CompanyResponse> Companies { get; set; }
        public required string Username { get; set; }
        public required IList<string> Roles { get; set; }
        public required string Email { get; set; }
    }
}
