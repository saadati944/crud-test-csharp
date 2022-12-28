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
namespace Mc2.CrudTest.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CustomerCreationFeatureFeature : object, Xunit.IClassFixture<CustomerCreationFeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CustomerCreationFeature.feature"
#line hidden
        
        public CustomerCreationFeatureFeature(CustomerCreationFeatureFeature.FixtureData fixtureData, Mc2_CrudTest_AcceptanceTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CustomerCreationFeature", "    The custoemr endpoint should create and persist a new customer", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="By using valid information customer should be created successfully")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerCreationFeature")]
        [Xunit.TraitAttribute("Description", "By using valid information customer should be created successfully")]
        public void ByUsingValidInformationCustomerShouldBeCreatedSuccessfully()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("By using valid information customer should be created successfully", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "lastName",
                            "dateOfBirth",
                            "phoneNumber",
                            "email",
                            "bankAccountNumbe"});
                table1.AddRow(new string[] {
                            "Ali",
                            "saadati",
                            "2000/01/02",
                            "+1334252345",
                            "sdt@mail.com",
                            "1234-5342-2344-5234"});
                table1.AddRow(new string[] {
                            "John",
                            "martin",
                            "1997/01/02",
                            "+3225234325",
                            "email2@email.com",
                            "6435-1942-9182-9128"});
#line 6
    testRunner.Given("Following customer informations", ((string)(null)), table1, "Given ");
#line hidden
#line 10
    testRunner.When("Calling CreateCustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
    testRunner.Then("New customers should be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Customer emails should be unique")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerCreationFeature")]
        [Xunit.TraitAttribute("Description", "Customer emails should be unique")]
        public void CustomerEmailsShouldBeUnique()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer emails should be unique", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "lastName",
                            "dateOfBirth",
                            "phoneNumber",
                            "email",
                            "bankAccountNumbe"});
                table2.AddRow(new string[] {
                            "Ali",
                            "saadati",
                            "2000/01/02",
                            "+1334252345",
                            "same@email.com",
                            "1234-5342-2344-5234"});
                table2.AddRow(new string[] {
                            "John",
                            "martin",
                            "1997/01/02",
                            "+3225234325",
                            "same@email.com",
                            "6435-1942-9182-9128"});
#line 14
    testRunner.Given("Following customer informations", ((string)(null)), table2, "Given ");
#line hidden
#line 18
    testRunner.When("Calling CreateCustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
    testRunner.Then("Only first customer should be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Combination of first name and last name and date of birth should be unique for ea" +
            "ch customer")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerCreationFeature")]
        [Xunit.TraitAttribute("Description", "Combination of first name and last name and date of birth should be unique for ea" +
            "ch customer")]
        public void CombinationOfFirstNameAndLastNameAndDateOfBirthShouldBeUniqueForEachCustomer()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Combination of first name and last name and date of birth should be unique for ea" +
                    "ch customer", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "lastName",
                            "dateOfBirth",
                            "phoneNumber",
                            "email",
                            "bankAccountNumbe"});
                table3.AddRow(new string[] {
                            "John",
                            "martin",
                            "1997/01/02",
                            "+1334252345",
                            "email1@email.com",
                            "1234-5342-2344-5234"});
                table3.AddRow(new string[] {
                            "John",
                            "martin",
                            "1997/01/02",
                            "+3225234325",
                            "email2@email.com",
                            "6435-1942-9182-9128"});
#line 22
    testRunner.Given("Following customer informations", ((string)(null)), table3, "Given ");
#line hidden
#line 26
    testRunner.When("Calling CreateCustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
    testRunner.Then("Only first customer should be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Customer should only be created with valid email address")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerCreationFeature")]
        [Xunit.TraitAttribute("Description", "Customer should only be created with valid email address")]
        public void CustomerShouldOnlyBeCreatedWithValidEmailAddress()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer should only be created with valid email address", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "lastName",
                            "dateOfBirth",
                            "phoneNumber",
                            "email",
                            "bankAccountNumbe"});
                table4.AddRow(new string[] {
                            "name1",
                            "lname1",
                            "1997/01/02",
                            "+6923049235",
                            "valid@email.com",
                            "1234-5342-2344-5234"});
                table4.AddRow(new string[] {
                            "name2",
                            "lname2",
                            "1998/01/02",
                            "+2342805394",
                            "",
                            "6435-1942-9182-9128"});
                table4.AddRow(new string[] {
                            "name3",
                            "lname3",
                            "1999/01/02",
                            "+6734572465",
                            "email2$email.com",
                            "6435-1942-9182-9128"});
                table4.AddRow(new string[] {
                            "name4",
                            "lname4",
                            "2000/01/02",
                            "+6356235235",
                            "invalidEmail.com",
                            "6435-1942-9182-9128"});
#line 30
    testRunner.Given("Following customer informations", ((string)(null)), table4, "Given ");
#line hidden
#line 36
    testRunner.When("Calling CreateCustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
    testRunner.Then("Only first customer should be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CustomerCreationFeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CustomerCreationFeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
