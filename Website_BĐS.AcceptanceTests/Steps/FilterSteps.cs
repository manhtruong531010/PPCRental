using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Website_BĐS.Models;
using Website_BĐS.AcceptanceTests.Common;
using Website_BĐS.AcceptanceTests.Drivers.Project;

namespace Website_BĐS.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "automated")]
    public class FilterSteps
    {
         private readonly SearchDriver _projectDriver;
        public FilterSteps(SearchDriver driver) 
        { _projectDriver = driver; }
        [When(@"I select the Project Type is '(.*)' data field")]
        public void WhenISelectTheProjectTypeIsDataField(string p0)
        {
                   
        }
        
        [When(@"I select the District is '(.*)'")]
        public void WhenISelectTheDistrictIs(string p0)
        {
            
        }
        
        [When(@"I select the Street is '(.*)'")]
        public void WhenISelectTheStreetIs(string p0)
        {
            
        }
        
        [When(@"I click Find button")]
        public void WhenIClickFindButton()
        {
           
        }
        [Then(@"The results should appear the projects selected '(.*)'")]
        public void ThenTheResultsShouldAppearTheProjectsSelected(Table p0)
        {
            _projectDriver.ShowList(p0);
        }

    }
}
