using FluentAssertions;
using LicApiTests.Dtos;
using LicApiTests.Models.Requests;
using LicUiTests.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LicApiTests.Steps
{
    [Binding]
    public class WorkpointManagementSteps : StepsBase
    {
        public WorkpointManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"All workpoints details are displayed in the result from (.*)")]
        public async Task ThenAllWorkpointsDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<WorkpointMapper>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Workpoints/GetWorkpointsResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<WorkpointMapper>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm the searched workpoint's data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmTheSearchedWorkpointsDataIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<WorkpointMapper>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Workpoints/GetDemoWorkpointResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<WorkpointMapper>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm the workpoint's 59 data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmTheWorkpointsDataIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<WorkpointAllDataMapper>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Workpoints/GetWorkpointByIdResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<WorkpointAllDataMapper>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm the searched user's workpoints are displayed in the result from (.*)")]
        [Then(@"I can confirm the searched company's workpoints are displayed in the result from (.*)")]
        public async Task ThenICanConfirmTheSearchedUsersWorkpointsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<WorkpointAllDataMapper>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Workpoints/GetWorkpointByUserIdResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<WorkpointAllDataMapper>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I confirm the response code from (.*) returns the new workpoint's (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromReturnsTheNewWorkpoints(string endpoint, string workpointKey, string workpointName)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<WorkpointMapper>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();
            responseData!.Name.Should().Be(workpointName);
            _scenarioContext.Add(workpointKey, responseData.Name);

        }

        [Then(@"I confirm the response code from (.*) returns the newly added workpoint's (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromGetWorkpointsReturnsTheNewWorkpoints(string endpoint, string idKey)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<WorkpointMapper>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();
            _scenarioContext.Add(idKey, responseData!.Id.ToString());
        }

        [When(@"I make a POST request to (.*) with the (.*) param to delete the recently added workpoint")]
        public async Task WhenIMakeAPOSTRequesWithTheParamToDeleteTheRecentlyAddedWorkpoint(string endpoint, string idKey)
        {
            var workpointToDeleteId = _scenarioContext.Get<string>(idKey);
            var removeWorkpointRequest = new RemoveWorkpointRequest();
            removeWorkpointRequest.Id = workpointToDeleteId;
            var response = await _client.PostAsJsonAsync(endpoint, removeWorkpointRequest);
            _scenarioContext.Add(endpoint, response);
        }

        [Then(@"I confirm (.*) doesn't return the recently added workpoint - (.*)")]
        public async Task ThenIConfirmGetWorkpointsDoesntReturnTheRecentlyAddedWorkpoint(string endpoint, string workpointName)
        {            
            var response = await _client.GetAsync(endpoint + "?Name=" + workpointName);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseData = JsonConvert.DeserializeObject<List<WorkpointMapper>>(await response.Content.ReadAsStringAsync());
            responseData.Should().BeEmpty();
        }
    }
}
