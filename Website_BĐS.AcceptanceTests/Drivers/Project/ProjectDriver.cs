using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using Website_BĐS.Controllers;
using TechTalk.SpecFlow;
using Website_BĐS.AcceptanceTests.Common;
using Website_BĐS.AcceptanceTests.Support;
using Website_BĐS.Areas.Agency.Controllers;
using FluentAssertions;

namespace Website_BĐS.AcceptanceTests.Drivers.Project
{
    public class ProjectDriver
    {
        private readonly SearchResultState _result;

        public ProjectDriver(SearchResultState result)
        {
            _result = result;
        }
        public void InsertProjecttoDB(TechTalk.SpecFlow.Table givenProjects)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,

                    };

                    //_context.ReferenceBooks.Add(
                    //        givenProjects.Header.Contains("Id") ? row["Id"] : givenProjects.,
                    //        property);

                    //db.Books.Add(book);
                }

                db.SaveChanges();
            }
        }

        public void Navigate(string mail, string pass)
        {
            using (var controller = new AccountController())
            {
                _result.ActionResult = controller.Login(mail,pass);
            }
        }


        public void ShowList(Table expectednameList)
        {
            //Arrange
            var expected = expectednameList.Rows.Select(x => x["PropertyName"]);

            var ShownName = _result.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownName, expectednameList);
        }
    }
}
