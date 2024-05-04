using TechTalk.SpecFlow;

namespace LicApiTests.Steps
{
    public class StepsBase
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly HttpClient _client;

        public StepsBase(ScenarioContext scenarioContext,
            HttpClient client)
        {
            _scenarioContext = scenarioContext;
            _client = client;
        }
    }
}
