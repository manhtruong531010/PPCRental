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

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding]
    public class UC006_PostPropertySteps
    {
				 private IWebDriver driver = new FirefoxDriver();
        [Given(@"have to homepage")]
        public void GivenIHaveToHomepage()
        {
            driver.Navigate().GoToUrl("http://localhost:31286/");
            Thread.Sleep(5);
        }
        [When(@"click login")]
        public void WhenIClickLogin()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(5);
        }
        [When(@"User Enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string username, string password, Table table)
        {
												//driver.Navigate().GoToUrl("http://localhost:31286/Account/Login");
            //    Thread.Sleep(5);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("lythihuyenchau@gmail.com");
            Thread.Sleep(5);
            driver.FindElement(By.Name("password")).SendKeys("123");
            Thread.Sleep(5);
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(5);
        }
        [When(@"i press create property")]
        public void WhenIPressCreateProperty()
        {
             driver.FindElement(By.LinkText("Create New Property")).Click();
            Thread.Sleep(5);
        }
        
        [When(@"i input new information")]
        public void WhenIInputNewInformation()
        {
            //editpropertyName
            driver.FindElement(By.Id("PropertyName")).Clear();
            driver.FindElement(By.Id("PropertyName")).SendKeys("City Gate");
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
												IWebElement FileUpload = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div/div[2]/div/div/input"));
            FileUpload.SendKeys(@"C:\Users\xuan nu\Desktop\TestUI\PPCver0.2\Website_BĐS.AcceptanceTests\image\kWi0hE0.jpg");

            //upload image
												IWebElement FileUploadImage = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div/div[3]/div/div/input"));
            FileUploadImage.SendKeys(@"C:\Users\xuan nu\Desktop\TestUI\PPCver0.2\Website_BĐS.AcceptanceTests\image\kWi0hE0.jpg");

            //edit district
            driver.FindElement(By.Id("select2-District_ID-container")).Click();
            Thread.Sleep(50);
            driver.FindElement(By.ClassName("select2-search__field")).SendKeys("Q.8" + Keys.Enter);
            Thread.Sleep(50);

            //edit ward
												//thêm id ="ward" trong ares => admin => agency => create
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
            driver.FindElement(By.Id("Price")).SendKeys("111");
            Thread.Sleep(5);

            //edit area
            driver.FindElement(By.Id("Area")).Clear();
            driver.FindElement(By.Id("Area")).SendKeys("111");
            Thread.Sleep(5);

            //edit bedroom
            driver.FindElement(By.Id("BedRoom")).Clear();
            driver.FindElement(By.Id("BedRoom")).SendKeys("1");
            Thread.Sleep(5);

            //edit bath room
            driver.FindElement(By.Id("BathRoom")).Clear();
            driver.FindElement(By.Id("BathRoom")).SendKeys("1");
            Thread.Sleep(5);

            //edit packing place
            driver.FindElement(By.Id("PackingPlace")).Clear();
            driver.FindElement(By.Id("PackingPlace")).SendKeys("111");
            Thread.Sleep(5);

        }

        [When(@"i click button post")]
        public void WhenIClickButtonPost()
        {
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div/div[14]/div/div[2]/input")).Click();
            Thread.Sleep(5);
        }
    }
}
