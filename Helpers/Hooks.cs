using AventStack.ExtentReports;
using BoDi;
using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;
using LicApiTests.Authentication;
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

        [BeforeScenario("LoginAsAdmin")]
        public async Task LoginAsAdmin()
        {
            HttpClientHandler handler = new();
           
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            HttpClient _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(AppSettings.LicApiUrl!);

            TokenLogic tokenLogic = new();

            var token = await tokenLogic.GetAuthAdminTokenAsync(_client);           

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            _objectContainer.RegisterInstanceAs(_client);

            var currentTest = _scenarioContext.ScenarioInfo.Title;
            _test = _report.CreateTest(currentTest);
            _currentTest = _test.CreateNode(currentTest);
        }

        [BeforeScenario("LoginAsCustomer")]
        public async Task LoginAsCustomer()
        {
            HttpClientHandler handler = new();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            HttpClient _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(AppSettings.LicApiUrl!);

            TokenLogic tokenLogic = new();

            var token = await tokenLogic.GetAuthCustomerTokenAsync(_client);

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            _objectContainer.RegisterInstanceAs(_client);

            var currentTest = _scenarioContext.ScenarioInfo.Title;
            _test = _report.CreateTest(currentTest);
            _currentTest = _test.CreateNode(currentTest);
        }

        [BeforeScenario("NotLoggedIn")]
        public void NotLoggedIn()
        {
            HttpClientHandler handler = new();
           
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

        [AfterScenario("UserCleanUp")]
        public void UserCleanUp()
        {
            string username = _scenarioContext.Get<string>("username");
            DbAccess.UserCleanUp(username);
        }

        [AfterScenario("ResetFirstname")]
        public void ResetFirstname()
        {
            string firstname = _scenarioContext.Get<string>("firstname");
            DbAccess.ResetFirstname(firstname);
        }
    }
}
