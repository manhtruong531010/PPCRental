using System;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding]
    public class UC001_FilterPropertySteps
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"Toi dang o trang Home")]
        public void GivenToiDangOTrangHome()
        {
            driver.Navigate().GoToUrl("http://localhost:31286/");
            Thread.Sleep(5);
        }
        
        [When(@"Toi chon House")]
        public void WhenToiChonHouse()
        {
            var option = driver.FindElement(By.Id("type"));
            var selectElement = new SelectElement(option);
            Thread.Sleep(5);
            selectElement.SelectByText("House");
        }
        
        [When(@"Toi dien Q\.Thu Duc va nhan chon tai Quan")]
        public void WhenToiDienQ_ThuDucVaNhanChonTaiQuan()
        {
            driver.FindElement(By.Id("select2-Quan-container")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("select2-search__field")).SendKeys("Q.Thủ Đức" + Keys.Enter);
            Thread.Sleep(500);
            
        }
        
        [When(@"Toi dien Binh Nguyen va nhan chon tai Duong")]
        public void WhenToiDienBinhNguyenVaNhanChonTaiDuong()
        {
            driver.FindElement(By.Id("select2-Duong-container")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("select2-search__field")).SendKeys("Bình Nguyên" + Keys.Enter);
            Thread.Sleep(500);
        }
        
        [When(@"Toi nhan nut Tim")]
        public void WhenToiNhanNutTim()
        {
            driver.FindElement(By.Name("btn-search")).Click();
            Thread.Sleep(700);
        }

        
    }
}
