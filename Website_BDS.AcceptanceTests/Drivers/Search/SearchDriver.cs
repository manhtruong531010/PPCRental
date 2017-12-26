using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using Website_BDS.AcceptanceTests.Support;
using Website_BDS.AcceptanceTests.Common;
using TechTalk.SpecFlow;
using Website_BĐS.Controllers;
using System.Web;
using System;

namespace Website_BDS.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly SearchResultState _state;
     
        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        /// <summary>
        /// Post property
        /// </summary>
        /// <param name="Property"></param>
        
        public void InsertBookToDB(Table Property)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in Property.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Content = row["Content"],
                        PropertyType_ID = int.Parse(row["PropertyType"]),
                        Price = int.Parse(row["Price"]),
                        District_ID = int.Parse(row["District"]),
                        UserID = int.Parse(row["UserID"]),
                        Status_ID = int.Parse(row["StatusID"])

                    };

                    //_context.ReferenceBooks.Add(
                    //        Property.Header.Contains("ID") ? row["ID"] : property.PropertyName,
                    //        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }
        //public void ListProperty()
        //{
        //    var controller = new HomeController();
        //    _state.ActionResult = controller.Index();
        //}
        public void Search(string loaiDA, string Quan, string Duong, string txtSearch, string txtmin, string txtmax)
        {
            var controller = new HomeController();
            int? district = null;
            int? type = null;
            int? duong = null;  
            var db = new Team33Entities();
            try{
                district = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == Quan).ID;
            }catch(NullReferenceException){
                district = null;
            }
            try
            {
                duong = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == Duong).ID;
            }
            catch (NullReferenceException)
            {
                district = null;
            }
            try
            {
                type = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == loaiDA).ID;
            }
            catch (NullReferenceException)
            {
                type = null;
            }
            _state.ActionResult = controller.Search(type, district, duong, txtSearch, txtmin, txtmax);
        }

        public void ShowBooks(string expectedTitlesString)
        {
            //Arrange
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');

            //Action
            var ShownBooks = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownBooks, expectedTitles);
        }

        public void ShowBooks(Table expectedBooks)
        {
            //Arrange
            var expectedTitles = expectedBooks.Rows.Select(r => r["PropertyName"]);

            //Action
            var ShownBooks = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownBooks, expectedTitles);
        }
    }
}
