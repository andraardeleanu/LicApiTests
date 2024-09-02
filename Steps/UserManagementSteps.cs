using FluentAssertions;
using LicApiTests.Models.Requests;
using LicApiTests.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LicApiTests.Steps
{
    [Binding]
    public class UserManagementSteps : StepsBase
    {
        public UserManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"I can confirm Andra Donca user is displayed in the result from (.*)")]
        public async Task ThenICanConfirmAndraDoncaUserIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<LoggedInResponse>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/User/LoggedInCustomer.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<LoggedInResponse>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I confirm the response code from (.*) returns the new user with (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromReturnsTheNewUsername(string endpoint, string key, string data)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<GetUserByUsernameResponse>(await response.Content.ReadAsStringAsync());

            responseData!.Username.Should().Be(data);
            _scenarioContext.Add(key, responseData.Username);
        }

        [Then(@"I confirm the response code from (.*) returns the new user's (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromGetUserByUsernameReturnsTheNewUsers(string endpoint, string key, string data)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<GetUserByUsernameResponse>(await response.Content.ReadAsStringAsync());

            responseData!.FirstName.Should().Be(data);
            _scenarioContext.Add(key, responseData.Username);
        }


        [When(@"I make a PATCH request to (.*) using '(.*)' file")]
        public async Task WhenIMakeAPATCHRequestUsingFile(string endpoint, string filePath)
        {
            var jsonString = await File.ReadAllTextAsync(filePath);
            var jsonBodyChangePassword = JsonConvert.DeserializeObject<ChangePasswordRequest>(jsonString);
            var responseChangePassword = await _client.PatchAsJsonAsync(endpoint, jsonBodyChangePassword);
            _scenarioContext.Add(endpoint, responseChangePassword);
        }

    }
}
