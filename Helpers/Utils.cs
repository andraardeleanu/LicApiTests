using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System.Net;
using TechTalk.SpecFlow;

namespace LicUiTests.Helpers
{
    public static class Utils
    {
        public static void AddOrUpdateDataInScenarioContext(ScenarioContext scenarioContext, string key, object value)
        {
            if (scenarioContext.ContainsKey(key))
            {
                scenarioContext.Remove(key);
                scenarioContext.Add(key, value);
            }
            else
            {
                scenarioContext.Add(key, value);
            }
        }       
    }
}
