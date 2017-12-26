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
using OpenQA.Selenium.Support.UI;
//using AutoItX3Lib;



namespace Website_BĐS.AcceptanceTests.StepDefinition
{
    [Binding]
    public class EditSteps
    {
        private IWebDriver driver = new FirefoxDriver();
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
												//driver.Navigate().GoToUrl("http://localhost:31286/Account/Login");
            //    Thread.Sleep(5);
            driver.FindElement(By.Name("email")).Clear();
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
        [When(@"i fill up")]
        public void WhenIFillUp()
        {
            //editpropertyName
            driver.FindElement(By.Id("PropertyName")).Clear();
            driver.FindElement(By.Id("PropertyName")).SendKeys("Benh Thanh Market");
            Thread.Sleep(5);

            //edit property type
            var option = driver.FindElement(By.Id("PropertyType_ID"));
            var selectElement = new SelectElement(option);
            Thread.Sleep(5);
            selectElement.SelectByText("Villa");

            //edit content
            driver.FindElement(By.Id("Content")).Clear();
            driver.FindElement(By.Id("Content")).SendKeys(" noi dung moi ");
            Thread.Sleep(5);

            //upload avatar
            IWebElement FileUpload = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div/div[2]/div/input"));
            FileUpload.SendKeys(@"C:\Users\xuan nu\Desktop\TestUI\PPCver0.2\Website_BĐS.AcceptanceTests\image\kWi0hE0.jpg");

            //upload image
            IWebElement FileUploadImage = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div/div[3]/div/input"));
            FileUploadImage.SendKeys(@"C:\Users\xuan nu\Desktop\TestUI\PPCver0.2\Website_BĐS.AcceptanceTests\image\kWi0hE0.jpg");

            //edit district
            driver.FindElement(By.Id("select2-District_ID-container")).Click();
            Thread.Sleep(50);
            driver.FindElement(By.ClassName("select2-search__field")).SendKeys("Q.8" + Keys.Enter);
            Thread.Sleep(50);

            //edit ward
												//thêm id ="ward" trong ares => admin => admin => edit
            driver.FindElement(By.Id("ward")).Click();
            Thread.Sleep(50);
            driver.FindElement(By.ClassName("select2-selection__rendered")).SendKeys("P.Linh Tây" + Keys.Enter);
            Thread.Sleep(50);

            //edit street
            driver.FindElement(By.Id("select2-Street_ID-container")).Click();
            Thread.Sleep(50);
            driver.FindElement(By.ClassName("select2-selection__rendered")).SendKeys("Đường số 2 - CX Đô Thành" + Keys.Enter);
            Thread.Sleep(50);
           
            //edit price
            driver.FindElement(By.Id("Price")).Clear();
            driver.FindElement(By.Id("Price")).SendKeys("333");
            Thread.Sleep(5);

            //edit area
            driver.FindElement(By.Id("Area")).Clear();
            driver.FindElement(By.Id("Area")).SendKeys("333");
            Thread.Sleep(5);

            //edit bedroom
            driver.FindElement(By.Id("BedRoom")).Clear();
            driver.FindElement(By.Id("BedRoom")).SendKeys("3");
            Thread.Sleep(5);

            //edit bath room
            driver.FindElement(By.Id("BathRoom")).Clear();
            driver.FindElement(By.Id("BathRoom")).SendKeys("3");
            Thread.Sleep(5);

            //edit packing place
            driver.FindElement(By.Id("PackingPlace")).Clear();
            driver.FindElement(By.Id("PackingPlace")).SendKeys("333");
            Thread.Sleep(5);

           
            //edit note
            driver.FindElement(By.Id("Note")).Clear();
            driver.FindElement(By.Id("Note")).SendKeys("note mới");
            Thread.Sleep(5);
        }
         // edit status
        [When(@"i select status")]
        public void whenISelectStatus()
        {
            var optionstatus = driver.FindElement(By.Id("Status_ID"));
            var selectElementStatus = new SelectElement(optionstatus);
            Thread.Sleep(5);
            selectElementStatus.SelectByText("Hết hạn");
        }
        [When(@"i click save")]
        public void WhenIClickSave()
        {
            driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(5);
        }
    }
}
