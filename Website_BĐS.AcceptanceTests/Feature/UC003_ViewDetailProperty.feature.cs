﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Website_BĐS.AcceptanceTests.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UC003_ViewDetailPropertyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "UC003_ViewDetailProperty.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UC003_ViewDetailProperty", "\tI can see detail of property", ProgrammingLanguage.CSharp, new string[] {
                        "automated"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "UC003_ViewDetailProperty")))
            {
                global::Website_BĐS.AcceptanceTests.Feature.UC003_ViewDetailPropertyFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType_ID",
                        "Content",
                        "Street_ID",
                        "Ward)ID",
                        "District_ID",
                        "Price",
                        "UnitPrice",
                        "Area",
                        "BedRoom",
                        "BathRoom",
                        "PackingPlace",
                        "UserID",
                        "Create_at",
                        "Create_post",
                        "Status",
                        "Note",
                        "Update_at",
                        "Sale_ID"});
            table1.AddRow(new string[] {
                        "PIS Top Apartment",
                        "PIS_6656-Edit-stamp.jpg",
                        "a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg" +
                            ",",
                        "1",
                        "The surrounding neighborhood is very much localized with a great number of local " +
                            "shops.",
                        "748",
                        "2",
                        "2",
                        "10000",
                        "VND",
                        "120m2",
                        "3",
                        "2",
                        "1",
                        "1",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "2"});
#line 6
 testRunner.Given("the following property", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Detail Property")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UC003_ViewDetailProperty")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        public virtual void ViewDetailProperty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Detail Property", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 12
 testRunner.When("I click button Chi tiet \'PIS Top Apartment\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType_ID",
                        "Content",
                        "Street_ID",
                        "Ward_ID",
                        "District_ID",
                        "Price",
                        "UnitPrice",
                        "Area",
                        "BedRoom",
                        "BathRoom",
                        "PackingPlace",
                        "Create_post"});
            table2.AddRow(new string[] {
                        "PIS Top Apartment",
                        "PIS_6656-Edit-stamp.jpg",
                        "a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg" +
                            ",",
                        "1",
                        "The surrounding neighborhood is very much localized with a great number of local " +
                            "shops.",
                        "748",
                        "2",
                        "2",
                        "10000",
                        "VND",
                        "120m2",
                        "3",
                        "2",
                        "1",
                        "2017-11-09"});
#line 13
 testRunner.Then("I should see property infomation", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
