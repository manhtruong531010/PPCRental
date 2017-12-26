using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website_BĐS.Models;
using FluentAssertions;
using Website_BDS.AcceptanceTests.Support;
using Website_BDS.AcceptanceTests.Common;
using TechTalk.SpecFlow;
using Website_BĐS.Controllers;
using System.Web.Mvc;
using Moq;
using System.IO;
using System.Web;
using TechTalk.SpecFlow.Assist;
using Website_BDS.UITests.Selenium.Config;
using Website_BDS.UITests.Selenium.Support;

namespace Website_BĐS.AcceptanceTests.Drivers
{
    public class PropertyDetailsDriver
    {
        //private const decimal BookDefaultPrice = 10;
        private ActionResult _result;
        private ProjectController _controller;
        private readonly CatalogContext _context;

        public PropertyDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        public void InsertUsertoBD(Table givenUser)
        {
            using (var db = new Team33Entities())
            {   
                foreach (var row in givenUser.Rows)
                {
                    var property = new USER
                    {
                        Email = row["Email"],
                        Password = row["Password"],
                        FullName = row["FullName"],
                        Phone = row["Phone"],
                        Address = row["Address"],
                        Role = row["Role"],
                        Status = Convert.ToBoolean(row["Status"])

                    };

                    db.USERs.Add(property);
                }

                db.SaveChanges();
            }
        }
        public void InsertProjecttoDB(Table givenProject)
        {

            using (var db = new Team33Entities())
            {
                foreach (var row in givenProject.Rows)
                {
                    //var district = db.DISTRICTs.ToList().FirstOrDefault(d => d.DistrictName == row["District"]);
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Avatar = row["Avatar"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["UserID"]).ID,
                        Created_at = Convert.ToDateTime(row["Create_at"]),
                        Create_post = Convert.ToDateTime(row["Create_post"]),
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        Note = row["Note"],
                        Updated_at = Convert.ToDateTime(row["Update_at"]),
                        Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale_ID"]).ID
                    };

                    //_context.ReferenceProject.Add(
                    //    givenProject.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                    //    property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void InsertFeaturetoBD(Table givenFeature)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in givenFeature.Rows)
                {
                    var property = new PROPERTY_FEATURE
                    {

                        Property_ID = db.PROPERTies.ToList().FirstOrDefault(x => x.PropertyName == row["Property"]).ID,
                        Feature_ID = db.FEATUREs.ToList().FirstOrDefault(x => x.FeatureName == row["Feature"]).ID
                    };

                    db.PROPERTY_FEATURE.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void ShowPropertyDetails(Table ShowPropertyDetails)
        {
            //Arrange
            var expectedPropertyDetails = ShowPropertyDetails.Rows.Single();

            //Act
            var actualPropertyDetails = _result.Model<PROPERTY>();

            //Assert
            actualPropertyDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedPropertyDetails["PropertyName"]);
        }
        public void OpenPropertyDetails(String propertyId)
        {
            PROPERTY property;
            using (var db = new Team33Entities())
            {
                property = db.PROPERTies.ToList().FirstOrDefault(x => x.PropertyName == propertyId);
            }
            using (var controller = new ProjectController())
            {
                _result = controller.Details(property.ID);
            }
                    

        }
        //public void createProperty(Table inputBook)
        //{
        //    var row = inputBook.Rows[0];
        //    var db = new Team33Entities();

        //    var book = new PROPERTY
        //    {
        //        PropertyName = row["PropertyName"],
        //        Avatar = row["Avarta"],
        //        Images = row["Images"],
        //        Content = row["Content"],
        //        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == (row["PropertyType"])).ID,
        //        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
        //        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
        //        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
        //        Price = int.Parse(row["Price"]),
        //        UnitPrice = row["UnitPrice"],
        //        Area = row["Area"],
        //        BedRoom = int.Parse(row["BedRoom"]),
        //        BathRoom = int.Parse(row["BathRoom"]),
        //        PackingPlace = int.Parse(row["PackingPlace"]),
        //        UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["UserID"]).ID,
        //        Created_at = Convert.ToDateTime(row["Create_at"]),
        //        Create_post = Convert.ToDateTime(row["Create_post"]),
        //        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
        //        Note = row["Note"],
        //        Updated_at = Convert.ToDateTime(row["Update_at"]),
        //        Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale_ID"]).ID
        //    };

        //    db.PROPERTies.Add(book);
        //    db.SaveChanges();
        //}

    }
}
