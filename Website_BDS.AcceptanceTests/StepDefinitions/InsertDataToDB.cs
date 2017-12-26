using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Website_BĐS.AcceptanceTests.Drivers;
namespace PPCProject.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    class InsertDataToDB
    {
        private readonly PropertyDetailsDriver _projectDriver;

        public InsertDataToDB(PropertyDetailsDriver driver)
        {
            _projectDriver = driver;
        }

        [Given(@"the following for user")]
        public void GivenTheFollowingForUser(Table givenUser)
        {
            _projectDriver.InsertUsertoBD(givenUser);
        }

        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProject)
        {
            _projectDriver.InsertProjecttoDB(givenProject);
        }

        [Given(@"the following property_feature")]
        public void GivenTheFollowingProperty_Feature(Table givenFeature)
        {
            _projectDriver.InsertFeaturetoBD(givenFeature);
        }

    }
}
