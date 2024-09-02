using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;
using FluentAssertions;
using LicApiTests.Authentication;
using LicApiTests.Models.Requests;
using LicApiTests.Models.Responses;
using LicUiTests.Helpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using TechTalk.SpecFlow;

namespace LicApiTests.Steps
{
    [Binding]
    public class CommonSteps : StepsBase
    {
        public CommonSteps(ScenarioContext scenarioContext, HttpClient client) : base(scenarioContext, client)
        {
        }

        [When(@"I login as Admin")]
        public async Task WhenILoginAsAdmin()
        {
            var jsonString = await File.ReadAllTextAsync("./Resources/Auth.json");
            var jsonBodyAuth = JsonConvert.DeserializeObject<AuthRequestBody>(jsonString);
            var response = await _client.PostAsJsonAsync("/login", jsonBodyAuth);
            var responseData = JsonConvert.DeserializeObject<AuthResponseBody>(await response.Content.ReadAsStringAsync());

        }


        [When(@"I make a (.*) request to (.*) with the (.*) param")]
        public async Task WhenIMakeARequestToWithParam(string httpMethod, string endpoint, string param = "")
        {
            switch (httpMethod)
            {
                case "POST":
                    {
                        if (!string.IsNullOrEmpty(param))
                        {
                            var jsonString = await File.ReadAllTextAsync(param);
                            var resp = await _client.PostAsJsonAsync(endpoint, jsonString);
                            Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, endpoint, resp);
                        }
                        break;
                    }
                case "PUT":
                case "PATCH":
                case "DELETE":
                    {
                        var id = int.Parse(_scenarioContext.Get<string>(param));
                        var resp = await _client.DeleteAsync(endpoint + "?id=" + id);
                        Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, endpoint, resp);
                        break;
                    }
                case "GET":
                    {
                        var resp = await _client.GetAsync(endpoint + "?" + param);
                        Utils.AddOrUpdateDataInScenarioContext(_scenarioContext, endpoint, resp);
                        break;
                    }
                default:
                    break;
            }
        }

        [When(@"I make a GET request to (.*) endpoint")]
        public async Task GivenIMakeARequestToEndpoint(string endpoint)
        {
            var response = await _client.GetAsync(AppSettings.LicApiUrl + endpoint);
            _scenarioContext.Add(endpoint, response);
        }

        [Then(@"I confirm the response code from (.*) is 200 OK")]
        public void ThenIConfirmTheResponseCodeIs(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Then(@"I confirm the response code from (.*) is 400 Bad Request")]
        public void ThenIConfirmTheResponseCodeFromAddCompanyIsBadRequest(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Then(@"I confirm the response code from (.*) is 403 Forbidden")]
        public void ThenIConfirmTheResponseCodeFromIsForbidden(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Then(@"I confirm the response code from (.*) is 401 Unauthorized")]
        public void ThenIConfirmTheResponseCodeFromAIsUnauthorized(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Then(@"I confirm the response code from (.*) is 500 Server Error")]
        public void ThenIConfirmTheResponseCodeFromAddCompanyIsServerError(string endpoint)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [When(@"I make a POST request to (.*) using '(.*)' file")]
        public async Task WhenIMakeAPOSTRequestToAddCompanyUsingFile(string endpoint, string filePath)
        {
            var jsonString = await File.ReadAllTextAsync(filePath);

            switch (endpoint)
            {
                case "/updateCompany":
                    var jsonBodyUpdateCompany = JsonConvert.DeserializeObject<UpdateCompanyRequest>(jsonString);
                    var responseUpdateCompany = await _client.PostAsJsonAsync(endpoint, jsonBodyUpdateCompany);
                    _scenarioContext.Add(endpoint, responseUpdateCompany);
                    break;
                case "/addCompany":
                    var jsonBodyAddCompany = JsonConvert.DeserializeObject<AddCompanyRequest>(jsonString);
                    var responseAddCompany = await _client.PostAsJsonAsync(endpoint, jsonBodyAddCompany);
                    _scenarioContext.Add(endpoint, responseAddCompany);
                    break;
                case "/addWorkpoint":
                    var jsonBodyAddWorkpoint = JsonConvert.DeserializeObject<AddWorkpointRequest>(jsonString);
                    var responseAddWorkpoint = await _client.PostAsJsonAsync(endpoint, jsonBodyAddWorkpoint);
                    _scenarioContext.Add(endpoint, responseAddWorkpoint);
                    break;
                case "/updateWorkpoint":
                    var jsonBodyUpdateWorkpoint = JsonConvert.DeserializeObject<UpdateWorkpointRequest>(jsonString);
                    var responseUpdateWorkpoint = await _client.PostAsJsonAsync(endpoint, jsonBodyUpdateWorkpoint);
                    _scenarioContext.Add(endpoint, responseUpdateWorkpoint);
                    break;
                case "/addProduct":
                    var jsonBodyAddProduct = JsonConvert.DeserializeObject<AddNewProductRequest>(jsonString);
                    var responseAddProduct = await _client.PostAsJsonAsync(endpoint, jsonBodyAddProduct);
                    _scenarioContext.Add(endpoint, responseAddProduct);
                    break;
                case "/updateProduct":
                    var jsonBodyUpdateProduct = JsonConvert.DeserializeObject<UpdateProductRequest>(jsonString);
                    var responseUpdateProduct = await _client.PostAsJsonAsync(endpoint, jsonBodyUpdateProduct);
                    _scenarioContext.Add(endpoint, responseUpdateProduct);
                    break;
                case "/addOrder":
                    var jsonBodyAddOrder = JsonConvert.DeserializeObject<AddOrderRequest>(jsonString);
                    var responseAddOrder = await _client.PostAsJsonAsync(endpoint, jsonBodyAddOrder);
                    _scenarioContext.Add(endpoint, responseAddOrder);
                    break;
                case "/updateStock":
                    var jsonBodyUpdateStock = JsonConvert.DeserializeObject<UpdateStockRequest>(jsonString);
                    var responseUpdateStock = await _client.PostAsJsonAsync(endpoint, jsonBodyUpdateStock);
                    _scenarioContext.Add(endpoint, responseUpdateStock);
                    break;
                case "/register":
                    var jsonBodyUserRegister = JsonConvert.DeserializeObject<RegisterRequest>(jsonString);
                    var responseUserRegister = await _client.PostAsJsonAsync(endpoint, jsonBodyUserRegister);
                    _scenarioContext.Add(endpoint, responseUserRegister);
                    break;
                case "/updateCustomer":
                    var jsonBodyUserUpdate = JsonConvert.DeserializeObject<UpdateCustomerRequest>(jsonString);
                    var responseUserUpdate = await _client.PostAsJsonAsync(endpoint, jsonBodyUserUpdate);
                    _scenarioContext.Add(endpoint, responseUserUpdate);
                    break;
            }
        }

        [Then(@"I confirm (.*) returns response status (.*) with validation message: (.*)")]
        public async Task ThenIConfirmResponseStatusIsWithValidationMessage(string endpoint, int responseStatus, string message)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(endpoint);
            var responseData = JsonConvert.DeserializeObject<Result>(await response.Content.ReadAsStringAsync());

            responseData!.Status.Should().Be(responseStatus);
            responseData.Message.Should().Be(message);
        }
    }
}
