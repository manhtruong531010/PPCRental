using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding]
    public class UC005_ViewListOfAgencyPropertySteps
    {
        private IWebDriver driver = new FirefoxDriver();
        //[Given(@"Toi dang o tai home page")]
        //public void GivenToiDangOTaiHomePage()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:31286/");
        //    Thread.Sleep(5);
        //}
        
        //[When(@"Toi nhan chon nut login")]
        //public void WhenToiNhanChonNutLogin()
        //{
        //    driver.FindElement(By.LinkText("Login")).Click();
        //    Thread.Sleep(5);
        //}
        
        //[When(@"Toi nhap mat khau va password")]
        //public void WhenToiNhapMatKhauVaPassword()
        //{
        //    driver.FindElement(By.Name("email")).SendKeys("dinhtrungtin@gmail.com");
        //    Thread.Sleep(5);
        //    driver.FindElement(By.Name("password")).SendKeys("123");
        //    Thread.Sleep(5);
        //}
        
        //[When(@"Toi chon View list property cua agency")]
        //public void WhenToiChonViewListPropertyCuaAgency()
        //{
        //   driver.FindElement(By.LinkText("ViewProperty")).Click();
        //    Thread.Sleep(5);
        //}
        
        //[Then(@"Toi chuyen sang trang login")]
        //public void ThenToiChuyenSangTrangLogin()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:31286/Account/Login");
        //    Thread.Sleep(5);
        //}
        
        //[Then(@"Toi nhan chon login va vao trang admin de thay danh sach du an")]
        //public void ThenToiNhanChonLoginVaVaoTrangAdminDeThayDanhSachDuAn()
        //{
        //    driver.FindElement(By.Id("login-button")).Click();
        //    Thread.Sleep(500);
        //}
        
       
    }
}
