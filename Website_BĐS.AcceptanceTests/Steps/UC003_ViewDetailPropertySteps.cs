using System;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding]
    public class UC003_ViewDetailPropertySteps
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"Toi dang o tai trang Home")]
        public void GivenToiDangOTaiTrangHome()
        {
            driver.Navigate().GoToUrl("http://localhost:31286/");
            Thread.Sleep(1000);
        }
        
        [When(@"Toi nhan chon nut Chi tiet")]
        public void WhenToiNhanChonNutChiTiet()
        {
            driver.FindElement(By.Id("btn-detail")).Click();
            Thread.Sleep(5);
        }
        
       
    }
}
