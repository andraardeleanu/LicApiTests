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

        [Then(@"I confirm the response code from (.*) returns the new order's (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromGetOrdersReturnsTheNewOrdersOrderNo(string endpoint, string key)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<Result<OrderResponse>>(await response.Content.ReadAsStringAsync())!;

            _scenarioContext.Add(key, responseData.Data!.OrderNo);
        }

        [Then(@"I confirm the response code from (.*) returns the new order id (.*) and (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromAddOrderReturnsTheNewOrderIdOrderNo(string endpoint, string idkey, string orderNokey)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<Result<OrderResponse>>(await response.Content.ReadAsStringAsync())!;

            _scenarioContext.Add(idkey, responseData.Data!.Id);
            _scenarioContext.Add(orderNokey, responseData.Data!.OrderNo);
        }

        [When(@"I make a POST request to (.*) for the order with (.*) param")]
        public async Task WhenIMakeAPOSTRequestToUpdateOrderStatusForTheOrderWithIdParam(string endpoint, string idKey)
        {
            var orderId = _scenarioContext.Get<int>(idKey);
            var updateStatusRequest = new UpdateOrderStatusRequest();
            updateStatusRequest.Id = orderId.ToString();
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
