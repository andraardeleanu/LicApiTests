using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;
using FluentAssertions;
using LicApiTests.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Json;

namespace LicApiTests.Authentication
{
    public class TokenLogic
    {
        private readonly HttpClient apiClient;
        public string Token;

        public TokenLogic(HttpClient apiClient)
        {
            this.apiClient = apiClient;
            Token = GetAuthTokenAsync().ToString()!;
        }

        public async Task<string> GetAuthTokenAsync()
        {
            var jsonString = await File.ReadAllTextAsync("./Resources/Auth.json");            
            var response = await apiClient.PostAsJsonAsync("/login", jsonString);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseData = JsonConvert.DeserializeObject<AuthResponseBody>(await response.Content.ReadAsStringAsync());            

            return responseData.token;
        }
    }
}
