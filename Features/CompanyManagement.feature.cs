﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LicApiTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CompanyManagement")]
    [NUnit.Framework.CategoryAttribute("CompanyManagement")]
    public partial class CompanyManagementFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "CompanyManagement"};
        
#line 1 "CompanyManagement.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CompanyManagement", "As a Licenta API consumer, I want to be able to manage companies", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot access /addCompany or other resources without using a valid user")]
        [NUnit.Framework.CategoryAttribute("NotLoggedIn")]
        public void CannotAccessAddCompanyOrOtherResourcesWithoutUsingAValidUser()
        {
            string[] tagsOfScenario = new string[] {
                    "NotLoggedIn"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot access /addCompany or other resources without using a valid user", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/AddNewCompanyRequ" +
                        "est.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then("I confirm the response code from /addCompany is 401 Unauthorized", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot access /addCompany or other resources if logged in as customer")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAccessAddCompanyOrOtherResourcesIfLoggedInAsCustomer()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot access /addCompany or other resources if logged in as customer", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/AddNewCompanyRequ" +
                        "est.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("I confirm the response code from /addCompany is 403 Forbidden", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get all companies")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetAllCompanies()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get all companies", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
 testRunner.When("I make a GET request to /getCompanies endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("I confirm the response code from /getCompanies is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get company by Name")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetCompanyByName()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get company by Name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.When("I make a GET request to /getCompanies with the Name=Demo Company param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.Then("I confirm the response code from /getCompanies is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
 testRunner.And("I can confirm Demo Company data is displayed in the result from /getCompanies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get company by Id")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetCompanyById()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get company by Id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 28
 testRunner.When("I make a GET request to /getCompanyById with the id=1 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.Then("I confirm the response code from /getCompanyById is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.And("I can confirm the searched company\'s data is displayed in the result from /getCom" +
                        "panyById", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validation message is displayed if company is not found by id")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void ValidationMessageIsDisplayedIfCompanyIsNotFoundById()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validation message is displayed if company is not found by id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 34
 testRunner.When("I make a GET request to /getCompanyById with the id=900 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
 testRunner.Then("I confirm the response code from /getCompanyById is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.And("I confirm /getCompanyById returns response status 1 with validation message: Comp" +
                        "ania cautata nu exista.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully add a new company")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        [NUnit.Framework.CategoryAttribute("CompanyCleanUp")]
        public void SuccessfullyAddANewCompany()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin",
                    "CompanyCleanUp"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully add a new company", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 40
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/AddNewCompanyRequ" +
                        "est.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then("I confirm the response code from /addCompany is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.When("I make a GET request to /getCompanies with the Name=Company API Test param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 43
 testRunner.Then("I confirm the response code from /getCompanies returns the new company\'s CUI - 45" +
                        "67801", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add a new company with an existing name")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void CannotAddANewCompanyWithAnExistingName()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add a new company with an existing name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/CompanyWithExisti" +
                        "ngNameRequest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("I confirm the response code from /addCompany is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.And("I confirm /addCompany returns response status 1 with validation message: Exista d" +
                        "eja o companie cu acest nume.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Both fields are mandatory for adding a new company - missing cui")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void BothFieldsAreMandatoryForAddingANewCompany_MissingCui()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Both fields are mandatory for adding a new company - missing cui", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 52
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 53
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/CompanyMissingCui" +
                        ".json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
 testRunner.Then("I confirm the response code from /addCompany is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
 testRunner.And("I confirm /addCompany returns response status 1 with validation message: Toate ca" +
                        "mpurile sunt obligatorii.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Both fields are mandatory for adding a new company - missing name")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void BothFieldsAreMandatoryForAddingANewCompany_MissingName()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Both fields are mandatory for adding a new company - missing name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 59
 testRunner.When("I make a POST request to /addCompany using \'./Resources/Company/CompanyMissingNam" +
                        "e.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
 testRunner.Then("I confirm the response code from /addCompany is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.And("I confirm /addCompany returns response status 1 with validation message: Toate ca" +
                        "mpurile sunt obligatorii.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully update company\'s name")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        [NUnit.Framework.CategoryAttribute("ResetCompanyName")]
        public void SuccessfullyUpdateCompanysName()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin",
                    "ResetCompanyName"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully update company\'s name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 64
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 65
 testRunner.When("I make a POST request to /updateCompany using \'./Resources/Company/UpdateCompanyR" +
                        "equest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 66
 testRunner.Then("I confirm the response code from /updateCompany is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 67
 testRunner.When("I make a GET request to /getCompanies with the Name=Update Company Test param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 68
 testRunner.Then("I confirm the response code from /getCompanies returns the new company\'s Name - U" +
                        "pdate Company Test-XYZ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot update company to an already existing name")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void CannotUpdateCompanyToAnAlreadyExistingName()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot update company to an already existing name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 71
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 72
 testRunner.When("I make a POST request to /updateCompany using \'./Resources/Company/UpdateCompanyE" +
                        "xistingNameRequest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 73
 testRunner.Then("I confirm the response code from /updateCompany is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.And("I confirm /updateCompany returns response status 1 with validation message: Exist" +
                        "a deja o companie cu acest nume.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion