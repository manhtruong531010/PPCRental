using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using Website_BĐS.Controllers;
using TechTalk.SpecFlow;
using Website_BĐS.AcceptanceTests.Common;
using Website_BĐS.AcceptanceTests.Support;
using FluentAssertions;
using Website_BĐS;

namespace Website_BĐS.AcceptanceTests.Drivers.Project
{
    
    public class SearchDriver
    {
        private readonly SearchResultState _result;

        public SearchDriver(SearchResultState result)
        {
            _result = result;
        }

        public void Navigate(string mail, string pass)
        {           
            var controller = new AccountController();
            _result.ActionResult = controller.Login(mail, pass);

           
        }

        public void Search(int searchTerm) 
        {
            var controller = new HomeController();
            _result.ActionResult = controller.Search(null,searchTerm,null);
        }

        public void ListPro()
        {
            var controllerIndex = new AccountController();
            //_result.ActionResult = controllerIndex.ViewDetail();//cai nay la ong khong co cai ham viewdetail trong accountcontrollerlun
        }

        public void ShowList(Table expectednameList)
        {
            //Arrange
            var expected = expectednameList.Rows.Select(x => x["PropertyName"]);
            var ShownName = _result.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownName, expected);
        }
    }
}
