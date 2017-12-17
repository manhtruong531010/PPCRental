using System;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using Website_BĐS.AcceptanceTests.Support;
using Website_BĐS.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;
using Website_BĐS.AcceptanceTests.Common;
//using Website_BĐS.UITests.Selenium.Support;

namespace Website_BĐS.AcceptanceTests.Drivers.BookDetails
{
    public class PropertyDetailsDriver
    {
        //private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public PropertyDetailsDriver(CatalogContext context)
        {
            _context = context;
        }
        
        public void InsertPropertyToDB(Table property)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in property.Rows)
                {
                    var Property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Avatar = row["Avatar"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == row["PropertyType"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = db.USERs.ToList().FirstOrDefault(x => x.Email == row["UserID"]).ID,
                        Created_at = DateTime.Parse(row["Created_at"]),
                        Create_post = DateTime.Parse(row["Create_post"]),
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        Note = row["Note"],
                        Updated_at = DateTime.Parse(row["Updated_at"]),
                        Sale_ID = int.Parse(row["Sale_ID"])


                    };

                    _context.ReferenceProperty.Add(
                         property.Header.Contains("Id") ? row["Id"] : Property.PropertyName,
                         Property);
                     
                    db.PROPERTies.Add(Property);
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
            var property = _context.ReferenceProperty.GetById(propertyId);
            using (var controller = new ProjectController())
            {
                _result = controller.Details(property.ID);
            }
                    

        }
    }
}
