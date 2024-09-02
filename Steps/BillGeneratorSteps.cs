using FluentAssertions;
using LicApiTests.Models.Requests;
using LicApiTests.Models.Responses;
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

        [When(@"I make a POST request to (.*) for the order bill with (.*) param")]
        public async Task WhenIMakeAPOSTRequestToBillGeneratorForTheOrderBillWithOrderNoParam(string endpoint, string orderNokey)
        {
            var orderNo = _scenarioContext.Get<string>(orderNokey);
            var billGeneratorRequest = new BillGeneratorRequest();
            billGeneratorRequest.OrderNo = orderNo;
            var response = await _client.PostAsJsonAsync(endpoint, billGeneratorRequest);
            _scenarioContext.Add(endpoint, response);
        }

        [Then(@"I confirm (.*) returns the bill for the new (.*), (.*) and Status - (.*)")]
        public async Task ThenIConfirmBillGeneratorReturnsTheNewBillWithANewId(string endpoint, string idKey, string orderNoKey, string status)
        {
            var orderId = _scenarioContext.Get<int>(idKey);
            var orderNo = _scenarioContext.Get<string>(orderNoKey);
            var response = await _client.GetAsync(endpoint + "?orderId=" + orderId);
            var responseData = JsonConvert.DeserializeObject<BillResponse>(await response.Content.ReadAsStringAsync())!;
            responseData.OrderNo.Should().Be(orderNo);
            responseData.Status.Should().Be(status);
        }

        [Then(@"I can confirm bill details for the selected orderId are displayed in the result from (.*)")]
        public async Task ThenICanConfirmBillDetailsForTheSelectedOrderIdAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<BillResponse>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Bills/GetBillDetailsResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<BillResponse>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }
    }
}
