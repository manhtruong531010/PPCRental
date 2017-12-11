using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Website_BĐS.AcceptanceTests.StepDefinition
{
    [Binding]
    public class EditSteps
    {
        private IWebDriver driver = new ChromeDriver();
        [Given(@"I have to homepage")]
        public void GivenIHaveToHomepage()
        {
            driver.Navigate().GoToUrl("http://localhost:31286/");
            Thread.Sleep(5);
        }
        [When(@"I click login")]
        public void WhenIClickLogin()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(5);
        }
        [When(@"When User Enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string username, string password, Table table)
        {
            driver.FindElement(By.Name("email")).SendKeys("dinhtrungtin@gmail.com");
            Thread.Sleep(5);
            driver.FindElement(By.Name("password")).SendKeys("123");
            Thread.Sleep(5);
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(5);
        }
        [When(@"when i press ViewProperty")]
        public void WhenIPressViewProperty()
        {
            driver.FindElement(By.LinkText("ViewProperty")).Click();
            Thread.Sleep(5);
        }
        [When(@"when i press Edit")]
        public void WhenIPressEdit()
        {
            driver.FindElement(By.LinkText("Edit")).Click();
            Thread.Sleep(5);
        }

    }
}
