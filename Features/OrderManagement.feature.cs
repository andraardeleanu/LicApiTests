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
    [NUnit.Framework.DescriptionAttribute("OrderManagement")]
    [NUnit.Framework.CategoryAttribute("OrderManagement")]
    public partial class OrderManagementFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "OrderManagement"};
        
#line 1 "OrderManagement.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "OrderManagement", "As a Licenta API consumer, I want to be able to manage products", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Cannot access /addOrder or other resources without using a valid user")]
        [NUnit.Framework.CategoryAttribute("NotLoggedIn")]
        public void CannotAccessAddOrderOrOtherResourcesWithoutUsingAValidUser()
        {
            string[] tagsOfScenario = new string[] {
                    "NotLoggedIn"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot access /addOrder or other resources without using a valid user", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/AddNewManualOrderReq" +
                        "uest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then("I confirm the response code from /addOrder is 401 Unauthorized", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get all orders")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetAllOrders()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get all orders", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.When("I make a GET request to /getOrders endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get orders by id")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrdersById()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get orders by id", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.When("I make a GET request to /getOrders with the Id=184 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
 testRunner.And("Order searched by id is displayed displayed in the result from /getOrders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get orders by orderNo")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrdersByOrderNo()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get orders by orderNo", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 23
 testRunner.When("I make a GET request to /getOrders with the OrderNo=2bf92285-b09b-4e04-a5b3-3dc5c" +
                        "27baadb param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.And("Order searched by id is displayed displayed in the result from /getOrders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get orders by workpoint id")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrdersByWorkpointId()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get orders by workpoint id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 29
 testRunner.When("I make a GET request to /getOrders with the WorkpointId=67 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.And("Order searched by id is displayed displayed in the result from /getOrders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get orders by workpoint id and status")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrdersByWorkpointIdAndStatus()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get orders by workpoint id and status", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 35
 testRunner.When("I make a GET request to /getOrders with the WorkpointId=67 & Status=Initializata " +
                        "param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 36
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.And("Order searched by id is displayed displayed in the result from /getOrders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get orders by order id and status")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrdersByOrderIdAndStatus()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get orders by order id and status", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 40
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 41
 testRunner.When("I make a GET request to /getOrders with the Id=184 & Status=Initializata param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.Then("I confirm the response code from /getOrders is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.And("Order searched by id is displayed displayed in the result from /getOrders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully add new manual order using valid data")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        [NUnit.Framework.CategoryAttribute("OrderCleanUp")]
        [NUnit.Framework.CategoryAttribute("OrderProductsReset")]
        public void SuccessfullyAddNewManualOrderUsingValidData()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer",
                    "OrderCleanUp",
                    "OrderProductsReset"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully add new manual order using valid data", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/AddNewManualOrderReq" +
                        "uest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 50
 testRunner.Then("I confirm the response code from /addOrder is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And("I confirm /getOrders returns the new order with a new OrderNo, Status=Initializat" +
                        "a and Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 350, Pending stock = 150", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders with duplicated products")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersWithDuplicatedProducts()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders with duplicated products", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 56
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 57
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrderDuplicate" +
                        "dProducts.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Au fost id" +
                        "entificate produse duplicate. Te rog sa revizuiesti comanda.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders without the product lists")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersWithoutTheProductLists()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders without the product lists", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 66
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 67
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 68
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrdersNoProduc" +
                        "ts.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 70
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 71
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Nu ai sele" +
                        "ctat niciun produs pentru comanda.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 73
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders with an invalid workpoint")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersWithAnInvalidWorkpoint()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders with an invalid workpoint", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 77
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 78
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 79
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrdersInvalidW" +
                        "orkpoint.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Nu ai sele" +
                        "ctat punctul de lucru pentru noua comanda. Daca este un punct de lucru nou, il p" +
                        "oti crea din tab-ul Puncte de lucru.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 83
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders with invalid quanitites of products")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersWithInvalidQuanititesOfProducts()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders with invalid quanitites of products", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 86
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 87
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 88
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 89
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrderInvalidQu" +
                        "antity.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 90
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 91
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Cantitatea" +
                        " setata pentru unul sau mai multe produse este invalida.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 93
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders if product\'s quantity is not enough")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersIfProductsQuantityIsNotEnough()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders if product\'s quantity is not enough", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 96
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 97
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 98
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 99
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrderNotEnough" +
                        "Quantity.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 100
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 101
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Verifica s" +
                        "tocul disponibil pentru produsele din comanda.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 103
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot add orders if there are invalid products")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        public void CannotAddOrdersIfThereAreInvalidProducts()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot add orders if there are invalid products", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 106
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 107
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 108
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 109
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/ManualOrderInvalidPr" +
                        "oduct.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 110
 testRunner.Then("I confirm the response code from /addOrder is 400 Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 111
 testRunner.And("I confirm /addOrder returns response status 1 with validation message: Produsul c" +
                        "autat nu exista.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 113
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully update order status")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        [NUnit.Framework.CategoryAttribute("OrderCleanUp")]
        [NUnit.Framework.CategoryAttribute("OrderProductsReset")]
        public void SuccessfullyUpdateOrderStatus()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin",
                    "OrderCleanUp",
                    "OrderProductsReset"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully update order status", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 116
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 117
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 118
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 119
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/AddNewManualOrderReq" +
                        "uest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 120
 testRunner.Then("I confirm the response code from /addOrder is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 121
 testRunner.And("I confirm /getOrders returns the new order with a new OrderNo, Status=Initializat" +
                        "a and Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 122
 testRunner.When("I make a POST request to /updateOrderStatus for the order with Id param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 123
 testRunner.Then("I confirm /getOrders returns the new order with a new OrderNo, Status=Procesata a" +
                        "nd Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Only admin can update order status to Procesata")]
        [NUnit.Framework.CategoryAttribute("LoginAsCustomer")]
        [NUnit.Framework.CategoryAttribute("OrderCleanUp")]
        [NUnit.Framework.CategoryAttribute("OrderProductsReset")]
        public void OnlyAdminCanUpdateOrderStatusToProcesata()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsCustomer",
                    "OrderCleanUp",
                    "OrderProductsReset"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Only admin can update order status to Procesata", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 126
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 127
 testRunner.When("I make a GET request to /getStockByProductId with the productId=53 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 128
 testRunner.Then("I confirm /getStockByProductId returns the correct stock data for productId - 53:" +
                        " Available stock = 500, Pending stock = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
 testRunner.When("I make a POST request to /addOrder using \'./Resources/Orders/AddNewManualOrderReq" +
                        "uest.json\' file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 130
 testRunner.Then("I confirm the response code from /addOrder is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 131
 testRunner.And("I confirm /getOrders returns the new order with a new OrderNo, Status=Initializat" +
                        "a and Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 132
 testRunner.When("I make a POST request to /updateOrderStatus for the order with Id param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 133
 testRunner.Then("I confirm the response code from /updateOrderStatus is 403 Forbidden", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully get order details")]
        [NUnit.Framework.CategoryAttribute("LoginAsAdmin")]
        public void SuccessfullyGetOrderDetails()
        {
            string[] tagsOfScenario = new string[] {
                    "LoginAsAdmin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully get order details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 136
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 137
 testRunner.When("I make a GET request to /getOrderDetails with the orderId=1191 param", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 138
 testRunner.Then("I confirm the response code from /getOrderDetails is 200 OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 139
 testRunner.And("I can confirm the searched order\'s details are displayed in the result from /getO" +
                        "rderDetails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
