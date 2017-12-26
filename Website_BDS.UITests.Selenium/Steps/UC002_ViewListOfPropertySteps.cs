using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Website_BĐS.AcceptanceTests.StepDefintions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"Toi dang o home page")]
        public void GivenToiDangOHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:31286/");
            Thread.Sleep(5);
        }

        [When(@"Toi bam nut login")]
        public void WhenToiBamNutLogin()
        {
            driver.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(5);
        }

        //[Then(@"Toi dang o trang login")]
        //public void ThenToiDangOTrangLogin()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:31286/Account/Login");
        //    Thread.Sleep(5);
        //}

        [When(@"Toi dien mat khau va password")]
        public void WhenToiDienMatKhauVaPassword()
        {
            driver.FindElement(By.Name("email")).SendKeys("lythihuyenchau@gmail.com");
            Thread.Sleep(5);
            driver.FindElement(By.Name("password")).SendKeys("123");
            Thread.Sleep(5);
        }

        [Then(@"Toi bam nut login va vao trang admin de thay danh sach du an")]
        public void ThenToiBamNutLoginVaVaoTrangAdminDeThayDanhSachDuAn()
        {
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(5);
        }

    }
}
