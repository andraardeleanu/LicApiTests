using FluentAssertions;
using LicApiTests.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LicApiTests.Steps
{
    [Binding]
    public class ProductManagementSteps : StepsBase
    {
        public ProductManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"All products details are displayed in the result from (.*)")]
        public async Task ThenAllProductsDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<ProductResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Products/GetProductsResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<ProductResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm Product Demo 1 data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmProductDemoDataIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<ProductResponse>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Products/GetProductDemo1Response.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<ProductResponse>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I confirm the response code from (.*) returns the new product's (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromReturnsTheNewProducts(string endpoint, string key, string name)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<ProductResponse>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();
            responseData!.Name.Should().Be(name);
            _scenarioContext.Add(key, responseData.Name);
        }

    }
}
