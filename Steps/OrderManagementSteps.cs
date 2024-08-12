using FluentAssertions;
using LicApiTests.Models.Requests;
using LicApiTests.Models.Responses;
using LicUiTests.Helpers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LicApiTests.Steps
{
    [Binding]
    public class OrderManagementSteps : StepsBase
    {
        public OrderManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"All orders details are displayed in the result from (.*)")]
        public async Task ThenAllOrdersDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Orders/GetAllOrdersResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"Order searched by id is displayed displayed in the result from (.*)")]
        public async Task ThenOrderSearchedByIdIsDisplayedDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Orders/GetOrderWithParams.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I confirm (.*) returns the new order with a new (.*), (.*) and (.*)")]
        public async Task ThenIConfirmTheNewOrderHasBeenPlacedWithANew(string endpoint, string orderNoKey, string param, string idKey)
        {
            var response = await _client.GetAsync(endpoint + "?" + param);
            var responseData = JsonConvert.DeserializeObject<List<OrderResponse>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();
            Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, orderNoKey, responseData!.OrderNo);
            Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, idKey, (responseData!.Id).ToString());
        }


        [Then(@"I confirm the response code from (.*) returns the new order's (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromGetOrdersReturnsTheNewOrdersOrderNo(string endpoint, string key, string orderNo)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<OrderResponse>(await response.Content.ReadAsStringAsync())!;

            responseData!.OrderNo.Should().Be(orderNo);
            _scenarioContext.Add(key, responseData.OrderNo);
        }

        [When(@"I make a POST request to (.*) for the order with (.*) param")]
        public async Task WhenIMakeAPOSTRequestToUpdateOrderStatusForTheOrderWithIdParam(string endpoint, string idKey)
        {
            var orderId = _scenarioContext.Get<string>(idKey);
            var updateStatusRequest = new UpdateOrderStatusRequest();
            updateStatusRequest.Id = orderId;
            var response = await _client.PostAsJsonAsync(endpoint, updateStatusRequest);
            _scenarioContext.Add(endpoint, response);
        }

        [Then(@"I can confirm the searched order's details are displayed in the result from (.*)")]
        public async Task ThenICanConfirmTheSearchedOrdersDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<OrderDetailsResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Orders/GetOrderDetailsResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<OrderDetailsResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }
    }
}
