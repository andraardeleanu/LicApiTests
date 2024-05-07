using FluentAssertions;
using LicApiTests.Dtos;
using LicApiTests.Mappers;
using LicApiTests.Models.Requests;
using LicUiTests.Helpers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TechTalk.SpecFlow;

namespace LicApiTests.Steps
{
    [Binding]
    public class BillGeneratorSteps : StepsBase
    {
        public BillGeneratorSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [When(@"I make a POST request to (.*) using '(.*)' file for (.*)")]
        public async Task WhenIMakeAPOSTRequestToBillGeneratorUsingFileFor(string endpoint, string filePath, string orderNoKey)
        {
            var orderNo = _scenarioContext.Get<string>(orderNoKey);
            var jsonString = await File.ReadAllTextAsync(filePath);
            var jsonBodyBillGenerator = JsonConvert.DeserializeObject<BillGeneratorRequest>(jsonString);
            jsonBodyBillGenerator!.OrderNo = orderNo;

            var responseBillGenerator = await _client.PostAsJsonAsync(endpoint, jsonBodyBillGenerator);
            Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, endpoint, responseBillGenerator);
        }

        [Then(@"I confirm (.*) returns the bill for the new (.*), (.*) and Status - (.*)")]
        public async Task ThenIConfirmBillGeneratorReturnsTheNewBillWithANewId(string endpoint, string idKey, string orderNoKey, string status)
        {
            var orderId = _scenarioContext.Get<string>(idKey);
            var orderNo = _scenarioContext.Get<string>(orderNoKey);
            var response = await _client.GetAsync(endpoint + "?orderId=" + orderId);
            var responseData = JsonConvert.DeserializeObject<BillMapper>(await response.Content.ReadAsStringAsync())!;
            responseData.OrderNo.Should().Be(orderNo);
            responseData.Status.Should().Be(status);
        }

        [Then(@"I can confirm bill details for the selected orderId are displayed in the result from (.*)")]
        public async Task ThenICanConfirmBillDetailsForTheSelectedOrderIdAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<BillMapper>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Bills/GetBillDetailsResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<BillMapper>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }
    }
}
