using AventStack.ExtentReports;
using BoDi;
using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;
using Gherkin;
using LicApiTests.Authentication;
using LicApiTests.Dtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace LicUiTests.Helpers
{
    [Binding]
    public class Hooks
    {
        public readonly ScenarioContext _scenarioContext;
        public readonly IObjectContainer _objectContainer;
        private static ExtentReports _report = new();
        private static ExtentTest? _test;
        private ExtentTest? _currentTest;
        private static DirectoryInfo? _resultsRoot;

        private static string _reportingPath = Path.Combine(Environment.CurrentDirectory + "/TestReports");
        private static string _screenshotsPath = Path.Combine(_reportingPath + "/Screenshots");

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }
        /*
        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            _objectContainer.RegisterInstanceAs(WebDriver.Driver);
        }*/

        [BeforeScenario("LoginAsAdmin")]
        public async Task LoginAsAdmin()
        {
            HttpClientHandler handler = new HttpClientHandler();

            handler.Credentials = new NetworkCredential
            {
                UserName = AppSettings.Username,
                Password = AppSettings.Password
            };
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(AppSettings.LicApiUrl!);

            //var tokenValue = new TokenLogic(client);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImVtYWlsIjoiYWRtaW5AbGljZW50YS5jb20iLCJqdGkiOiIyNDYxMGI2OS0zNThiLTRmZDQtYWI0MC01MDU1NGNiMWUxMzkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTcxNTE3NjU3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1NzY3OC8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjU3Njc4LyJ9.BJ3_DAUduCgeVwqCN78uyszGyIaNsb6TC7KfcESlSOc");

            _objectContainer.RegisterInstanceAs(client);

            var currentTest = _scenarioContext.ScenarioInfo.Title;
            _test = _report.CreateTest(currentTest);
            _currentTest = _test.CreateNode(currentTest);
        }

        [BeforeScenario("LoginAsCustomer")]
        public async Task LoginAsCustomer()
        {
            HttpClientHandler handler = new HttpClientHandler();

            handler.Credentials = new NetworkCredential
            {
                UserName = AppSettings.Username,
                Password = AppSettings.Password
            };
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(AppSettings.LicApiUrl!);

            //var tokenValue = new TokenLogic(client);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjdXN0b25lIiwiZW1haWwiOiJjdXN0b25lQGdsbWFpLmNvbSIsImp0aSI6IjJiZDk2N2Y4LTJhZjMtNDczOC05ODAzLTMzMmNhMjU5YTczNCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkN1c3RvbWVyIiwiZXhwIjoxNzE1MTUzODUyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjU3Njc4LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTc2NzgvIn0.OtFAdTpfO8n26AeV3oZ-lMo0md2cQ0a9TFdvKyP5Ojk");

            _objectContainer.RegisterInstanceAs(client);

            var currentTest = _scenarioContext.ScenarioInfo.Title;
            _test = _report.CreateTest(currentTest);
            _currentTest = _test.CreateNode(currentTest);
        }

        [BeforeScenario("NotLoggedIn")]
        public async Task NotLoggedIn()
        {
            HttpClientHandler handler = new HttpClientHandler();

            handler.Credentials = new NetworkCredential
            {
                UserName = AppSettings.Username,
                Password = AppSettings.Password
            };
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(AppSettings.LicApiUrl!);

            _objectContainer.RegisterInstanceAs(client);

            var currentTest = _scenarioContext.ScenarioInfo.Title;
            _test = _report.CreateTest(currentTest);
            _currentTest = _test.CreateNode(currentTest);
        }

        [AfterScenario("CompanyCleanUp")]
        public void CompanyCleanUp()
        {
            string cui = _scenarioContext.Get<string>("CUI");
            DbAccess.CompanyCleanUp(cui);
        }

        [AfterScenario("ResetCompanyName")]
        public void ResetCompanyName()
        {
            string name = _scenarioContext.Get<string>("Name");
            DbAccess.ResetCompanyName(name);
        }

        [AfterScenario("WorkpointCleanUp")]
        public void WorkpointCleanUp()
        {
            string name = _scenarioContext.Get<string>("Name");
            DbAccess.WorkpointCleanUp(name);
        }

        [AfterScenario("ResetWorkpointData")]
        public void ResetWorkpointData()
        {
            string name = _scenarioContext.Get<string>("Name");
            DbAccess.ResetWorkpointData(name);
        }

        [AfterScenario("ProductCleanUp")]
        public void ProductCleanUp()
        {
            string name = _scenarioContext.Get<string>("Name");
            DbAccess.ProductCleanUp(name);
        }

        [AfterScenario("ResetProductName")]
        public void ResetProductName()
        {
            string name = _scenarioContext.Get<string>("Name");
            DbAccess.ResetProductName(name);
        }

        [AfterScenario("OrderCleanUp")]
        public void OrderCleanUp()
        {
            string orderNo = _scenarioContext.Get<string>("OrderNo");
            DbAccess.OrderCleanUp(orderNo);
        }

        [AfterScenario("OrderProductsReset")]
        public void OrderProductsReset()
        {
            string productId = _scenarioContext.Get<string>("productId");
            DbAccess.OrderProductsReset(productId);
        }

        [AfterScenario("BillCleanUp")]
        public void BillCleanUp()
        {
            string OrderNo = _scenarioContext.Get<string>("OrderNo");
            DbAccess.BillCleanUp(OrderNo);
        }
    }
}
