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
namespace Website_BDS.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class EditFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "UC004_EditProperty.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Edit", "\tI can edit detail of property", ProgrammingLanguage.CSharp, new string[] {
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Edit")))
            {
                global::Website_BDS.AcceptanceTests.Features.EditFeature.FeatureSetup(null);
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
                        "Email",
                        "Password",
                        "FullName",
                        "Phone",
                        "Address",
                        "Role",
                        "Status"});
            table1.AddRow(new string[] {
                        "lythihuyenchau@gmail.com",
                        "123456",
                        "Lý Châu",
                        "0999580654",
                        "Trần Hưng Đạo",
                        "1",
                        "True"});
            table1.AddRow(new string[] {
                        "Manhtruong@gmail.com",
                        "123456",
                        "Mạnh Trương",
                        "01687631718",
                        "Cô Giang",
                        "0",
                        "True"});
#line 6
 testRunner.Given("the following for user", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType",
                        "Content",
                        "Street",
                        "Ward",
                        "District",
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
            table2.AddRow(new string[] {
                        "PIS Top Apartment",
                        "PIS_6656-Edit-stamp.jpg",
                        "a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg" +
                            "",
                        "Apartment",
                        "The surrounding neighborhood is very much localized with a great number of local " +
                            "shops.",
                        "Cô Bắc",
                        "P.Cô Giang",
                        "Q.1",
                        "10000",
                        "VND",
                        "120m2",
                        "3",
                        "2",
                        "1",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Lưu nháp",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
            table2.AddRow(new string[] {
                        "ViLa Q7",
                        "images172300301.jpg",
                        "images172300301.jpg",
                        "Villa",
                        "Brand new apartments with unbelievable river and city view, completely renovated " +
                            "and tastefully furnished.",
                        "Nguyễn Thị Thập",
                        "P.Phú Mỹ",
                        "Q.7",
                        "70000",
                        "VND",
                        "120m2",
                        "3",
                        "4",
                        "1",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
            table2.AddRow(new string[] {
                        "PIS Serviced Apartment – Style",
                        "sunshine-benthanh-cityhome-10-stamp174228283.jpg",
                        "a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg",
                        "Office",
                        "The well equipped kitchen is opened on a cozy living room and a dining area with " +
                            "table and chairs..",
                        "Bền Văn Đồn",
                        "P.03",
                        "Q.4",
                        "30000",
                        "VND",
                        "130m2",
                        "2",
                        "3",
                        "1",
                        "Sơn Lê",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Khá Trần"});
            table2.AddRow(new string[] {
                        "Vinhomes Central Park L2 – Duong’s Apartment",
                        "PIS_7389-Edit-stamp.jpg",
                        "images1702244617042862.jpg",
                        "Villa",
                        "Vinhomes Central Park is a new development that is in the heart of everything tha" +
                            "t Ho Chi Minh has to offer.",
                        "Bà Hạt",
                        "P.02",
                        "Q.10",
                        "110000",
                        "VND",
                        "150m2",
                        "4",
                        "2",
                        "1",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Khá Trần"});
            table2.AddRow(new string[] {
                        "Saigon Pearl Ruby Block",
                        "PIS_7319-Edit-stamp.jpg",
                        "images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg",
                        "Apartment",
                        "Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker " +
                            "Area, 23/9 park…",
                        "Chu Văn An",
                        "P.Long Bình",
                        "Q.9",
                        "30000",
                        "VND",
                        "130m2",
                        "3",
                        "5",
                        "1",
                        "Sơn Lê",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
#line 10
 testRunner.And("the following project", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Feature"});
            table3.AddRow(new string[] {
                        "PIS Top Apartment",
                        "Vườn"});
            table3.AddRow(new string[] {
                        "PIS Top Apartment",
                        "Hồ bơi"});
            table3.AddRow(new string[] {
                        "ViLa Q7",
                        "Chỗ đậu xe"});
            table3.AddRow(new string[] {
                        "ViLa Q7",
                        "Phòng tập Gym"});
            table3.AddRow(new string[] {
                        "ViLa Q7",
                        "Hồ bơi"});
            table3.AddRow(new string[] {
                        "PIS Serviced Apartment – Style",
                        "Thang máy"});
            table3.AddRow(new string[] {
                        "Vinhomes Central Park L2 – Duong’s Apartment",
                        "Sàn gỗ"});
            table3.AddRow(new string[] {
                        "Vinhomes Central Park L2 – Duong’s Apartment",
                        "Cho nuôi thú cưng"});
            table3.AddRow(new string[] {
                        "Saigon Pearl Ruby Block",
                        "Vườn"});
#line 17
 testRunner.And("the following property_feature", ((string)(null)), table3, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Edit Agency Project")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Edit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        public virtual void EditAgencyProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Agency Project", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 31
 testRunner.Given("I enterd \'Manhtruong@gmail.com\' and \'123456\' into Login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And("I have navigate to View List of Agency Project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I clicked edit of \'Saigon Pearl Ruby Block\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType",
                        "Content",
                        "Street",
                        "Ward",
                        "District",
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
            table4.AddRow(new string[] {
                        "Saigon Pearl Ruby Block 2",
                        "PIS_7319-Edit-stamp.jpg",
                        "images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg",
                        "Apartment",
                        "Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker " +
                            "Area, 23/9 park…",
                        "Chu Văn An",
                        "P.Long Bình",
                        "Q.9",
                        "30000",
                        "VND",
                        "130m2",
                        "3",
                        "5",
                        "1",
                        "Sơn Lê",
                        "2017-11-09",
                        "2017-11-09",
                        "Lưu nháp",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
#line 34
 testRunner.And("I edit my properties like the following", ((string)(null)), table4, "And ");
#line 37
 testRunner.And("I have navigate to View List of Agency Project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType",
                        "Content",
                        "Street",
                        "Ward",
                        "District",
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
            table5.AddRow(new string[] {
                        "PIS Top Apartment",
                        "PIS_6656-Edit-stamp.jpg",
                        "a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg" +
                            "",
                        "Apartment",
                        "The surrounding neighborhood is very much localized with a great number of local " +
                            "shops.",
                        "Cô Bắc",
                        "P.Cô Giang",
                        "Q.1",
                        "100000",
                        "VND",
                        "120m2",
                        "100",
                        "100",
                        "100",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Lưu nháp",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
            table5.AddRow(new string[] {
                        "ViLa Q7",
                        "images172300301.jpg",
                        "images172300301.jpg",
                        "Villa",
                        "Brand new apartments with unbelievable river and city view, completely renovated " +
                            "and tastefully furnished.",
                        "Nguyễn Thị Thập",
                        "P.Phú Mỹ",
                        "Q.7",
                        "70000",
                        "VND",
                        "120m2",
                        "3",
                        "4",
                        "1",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
            table5.AddRow(new string[] {
                        "PIS Serviced Apartment – Style",
                        "sunshine-benthanh-cityhome-10-stamp174228283.jpg",
                        "a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg",
                        "Office",
                        "The well equipped kitchen is opened on a cozy living room and a dining area with " +
                            "table and chairs..",
                        "Bền Văn Đồn",
                        "P.03",
                        "Q.4",
                        "30000",
                        "VND",
                        "130m2",
                        "2",
                        "3",
                        "1",
                        "Sơn Lê",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Khá Trần"});
            table5.AddRow(new string[] {
                        "Vinhomes Central Park L2 – Duong’s Apartment",
                        "PIS_7389-Edit-stamp.jpg",
                        "images1702244617042862.jpg",
                        "Villa",
                        "Vinhomes Central Park is a new development that is in the heart of everything tha" +
                            "t Ho Chi Minh has to offer.",
                        "Bà Hạt",
                        "P.02",
                        "Q.10",
                        "110000",
                        "VND",
                        "150m2",
                        "4",
                        "2",
                        "1",
                        "Lý Châu",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Khá Trần"});
            table5.AddRow(new string[] {
                        "Saigon Pearl Ruby Block 2",
                        "2.jpg",
                        "1.jpg,2.jpg,3.jpg",
                        "Apartment",
                        "Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker " +
                            "Area, 23/9 park…",
                        "Chu Văn An",
                        "P.Long Bình",
                        "Q.9",
                        "30000",
                        "VND",
                        "130m2",
                        "3",
                        "5",
                        "1",
                        "Sơn Lê",
                        "2017-11-09",
                        "2017-11-09",
                        "Lưu nháp",
                        "Done",
                        "2017-11-23",
                        "Chi Võ"});
#line 38
 testRunner.Then("I should see my project", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
