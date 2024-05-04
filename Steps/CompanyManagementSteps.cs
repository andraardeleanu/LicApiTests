using FluentAssertions;
using LicApiTests.Dtos;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LicApiTests.Steps
{
    [Binding]
    public class CompanyManagementSteps : StepsBase
    {
        public CompanyManagementSteps(ScenarioContext scenarioContext, HttpClient client)
           : base(scenarioContext, client)
        {
        }

        [Then(@"All companies details are displayed in the result from (.*)")]
        public async Task ThenICanConfirmAllCompaniesDetailsAreDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<IEnumerable<CompanyMapper>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Company/GetCompaniesResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<IEnumerable<CompanyMapper>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm Demo Company data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmDataIsDisplayedInTheResultFrom(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<CompanyMapper>>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Company/GetDemoCompanyResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<List<CompanyMapper>>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }

        [Then(@"I can confirm the searched company's data is displayed in the result from (.*)")]
        public async Task ThenICanConfirmTheSearchedCompanysDataIsDisplayedInTheResultFromG(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<CompanyMapper>(await response.Content.ReadAsStringAsync());

            string expectedResponse = File.ReadAllText("./Resources/Company/GetDemoCompanyByIdResponse.json");
            var expectedResponseJson = JsonConvert.DeserializeObject<CompanyMapper>(expectedResponse);

            responseData.Should().BeEquivalentTo(expectedResponseJson);
        }


        [Then(@"I confirm the response code from (.*) returns the new company's (.*) - (.*)")]
        public async Task ThenIConfirmTheResponseCodeFromIsReturnsTheNewCompanys(string endpoint, string key, string data)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<List<CompanyMapper>>(await response.Content.ReadAsStringAsync())!.FirstOrDefault();

            if (key == "CUI")
            {
                responseData!.Cui.Should().Be(data);
                _scenarioContext.Add(key, responseData.Cui);
            }
            else
            {
                responseData!.Name.Should().Be(data);
                _scenarioContext.Add(key, responseData.Name);
            }
        }
    }
}
