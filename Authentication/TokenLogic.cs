using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace LicApiTests.Authentication
{
    public class TokenLogic
    {
        public async Task<string> GetAuthAdminTokenAsync(HttpClient apiClient)
        {

            var jsonString = await File.ReadAllTextAsync("./Resources/AuthAdmin.json");
            var jsonBodyAuth = JsonConvert.DeserializeObject<AuthRequestBody>(jsonString);

            jsonBodyAuth!.Username = AppSettings.UsernameAdmin!;
            jsonBodyAuth!.Password = AppSettings.PasswordAdmin!;

            var response = await apiClient.PostAsJsonAsync("/login", jsonBodyAuth);
            var responseData = JsonConvert.DeserializeObject<AuthResponseBody>(await response.Content.ReadAsStringAsync());

            return responseData!.Token;
        }

        public async Task<string> GetAuthCustomerTokenAsync(HttpClient apiClient)
        {

            var jsonString = await File.ReadAllTextAsync("./Resources/AuthCustomer.json");
            var jsonBodyAuth = JsonConvert.DeserializeObject<AuthRequestBody>(jsonString);

            jsonBodyAuth!.Username = AppSettings.UsernameCustomer!;
            jsonBodyAuth!.Password = AppSettings.PasswordCustomer!;

            var response = await apiClient.PostAsJsonAsync("/login", jsonBodyAuth);
            var responseData = JsonConvert.DeserializeObject<AuthResponseBody>(await response.Content.ReadAsStringAsync());

            return responseData!.Token;
        }
    }
}
