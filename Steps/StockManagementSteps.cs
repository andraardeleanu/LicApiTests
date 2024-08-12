using FluentAssertions;
using LicApiTests.Models.Responses;
using LicUiTests.Helpers;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LicApiTests.Steps
{
    [Binding]
    public class StockManagementSteps : StepsBase
    {
        public StockManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"All stocks details are displayed in the result from (.*)")]
        public async Task ThenAllStocksDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<StockResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Stock/GetStocksResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<StockResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm stock for Product Demo 1 data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmStockForProductDemoDataIsDisplayedInTheResultFromGetStocks(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<StockResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Stock/GetProductStockTestApi.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<StockResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm searched stock data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmSearchedStockDataIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<StockResponse>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Stock/GetStockByIdResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<StockResponse>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm searched product returns the expected stock (.*)")]
        public async Task ThenICanConfirmSearchedProductReturnsTheExpectedStock(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<StockResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Stock/GetStockByProductIdResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<StockResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I confirm (.*) returns the correct stock data for (.*) - (.*): Available stock = (.*), Pending stock = (.*)")]
        public async Task ThenIConfirmStockDataIsCorrectFormProductId_AvailableStockPendingStock(string endpoint, string productKey, string productId, int availableStock, int pendingStock)
        {
            Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, productKey, productId);
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<StockResponse>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();

            responseData!.AvailableStock.Should().Be(availableStock);
            responseData!.PendingStock.Should().Be(pendingStock);                       
        }

    }
}
