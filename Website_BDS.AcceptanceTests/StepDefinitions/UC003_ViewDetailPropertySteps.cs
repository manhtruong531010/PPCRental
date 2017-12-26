using System;
using TechTalk.SpecFlow;
using System.Threading;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
using Website_BĐS.AcceptanceTests.Drivers;


namespace Website_BĐS.AcceptanceTests.Steps
{
     [Binding, Scope(Tag = "automated")]
    public class UC003_ViewDetailPropertySteps
    {
        //private IWebDriver driver = new FirefoxDriver();
        //private readonly ProjectDriver _projectDriver;
        private readonly PropertyDetailsDriver _PropertyDetailsDriver;

        public UC003_ViewDetailPropertySteps(PropertyDetailsDriver driver) 
        { 
            _PropertyDetailsDriver = driver; 

        }

        [When(@"I click button Chi tiet '(.*)'")]
        public void WhenIClickButtonChiTiet(string p0)
        {
            _PropertyDetailsDriver.OpenPropertyDetails(p0);
        }


        [Then(@"I should see property infomation")]
        public void ThenIShouldSeePropertyInfomation(Table table)
        {
            _PropertyDetailsDriver.ShowPropertyDetails(table);
        }


        
       
    }
}
