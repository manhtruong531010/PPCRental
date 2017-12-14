using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Website_BĐS.UITests.Selenium
{
    [Binding, Scope(Tag="web")]
    public class UC02_ViewListOfProjectSteps
    {
        [Given(@"I am at Login page")]
        public void GivenIAmAtLoginPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input '(.*)' and '(.*)'")]
        public void WhenIInputAnd(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see my own projects")]
        public void ThenIShouldSeeMyOwnProjects(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
