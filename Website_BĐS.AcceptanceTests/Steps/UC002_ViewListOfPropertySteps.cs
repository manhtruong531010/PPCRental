using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Website_BĐS.AcceptanceTests.Drivers.Project;

namespace Website_BĐS.AcceptanceTests.StepDefintions
{
    [Binding]
    public class LoginSteps
    {
        //private IWebDriver driver = new FirefoxDriver();
        private readonly ProjectDriver _projectDriver;


        public LoginSteps(ProjectDriver driver) { _projectDriver = driver; }


        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProjects)
        {
            _projectDriver.InsertProjecttoDB(givenProjects);
        }

        [When(@"I input '(.*)' and '(.*)' into Login page")]
        public void WhenIInputAndIntoLoginPage(string email, string password)
        {
            _projectDriver.Navigate(email, password);

        }

        [Then(@"I should see my own projects")]
        public void ThenIShouldSeeMyOwnProjects(Table expectedList)
        {
            _projectDriver.ShowList(expectedList);
        }

        //[Given(@"Toi dang o home page")]
        //public void GivenToiDangOHomePage()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:31286/");
        //    Thread.Sleep(5);
        //}

        //[When(@"Toi bam nut login")]
        //public void WhenToiBamNutLogin()
        //{
        //    driver.FindElement(By.LinkText("Login")).Click();
        //    Thread.Sleep(5);
        //}

        //[Then(@"Toi dang o trang login")]
        //public void ThenToiDangOTrangLogin()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:31286/Account/Login");
        //    Thread.Sleep(5);
        //}

        //[When(@"Toi dien mat khau va password")]
        //public void WhenToiDienMatKhauVaPassword()
        //{
        //    driver.FindElement(By.Name("email")).SendKeys("lythihuyenchau@gmail.com");
        //    Thread.Sleep(5);
        //    driver.FindElement(By.Name("password")).SendKeys("1");
        //    Thread.Sleep(5);
        //}

        //[Then(@"Toi bam nut login va vao trang admin de thay danh sach du an")]
        //public void ThenToiBamNutLoginVaVaoTrangAdminDeThayDanhSachDuAn()
        //{
        //    driver.FindElement(By.Id("login-button")).Click();
        //    Thread.Sleep(5);
        //}

    }

}
