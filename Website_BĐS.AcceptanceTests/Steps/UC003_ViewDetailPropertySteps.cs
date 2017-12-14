using System;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Website_BĐS.AcceptanceTests.Drivers.Project;

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding]
    public class UC003_ViewDetailPropertySteps
    {
        private IWebDriver driver = new FirefoxDriver();
        private readonly ProjectDriver _projectDriver;

        public UC003_ViewDetailPropertySteps(ProjectDriver driver) { _projectDriver = driver; }

        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click button Chi tiet")]
        public void WhenIClickButtonChiTiet()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see property infomation")]
        public void ThenIShouldSeePropertyInfomation(Table table)
        {
            ScenarioContext.Current.Pending();
        }


        
       
    }
}
