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
        private const decimal BookDefaultPrice = 10;
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
                        Avatar = row["Avarta"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = int.Parse(row["PropertyType_ID"]),
                        Street_ID = int.Parse(row["Street_ID"]),
                        Ward_ID = int.Parse(row["Ward_ID"]),
                        District_ID = int.Parse(row["District_ID"]),
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = int.Parse(row["UserID"]),
                        Created_at = DateTime.Parse(row["Created_at"]),
                        Create_post = DateTime.Parse(row["Create_post"]),
                        Status_ID = int.Parse(row["Status"]),
                        Note = row["Note"],
                        Updated_at = DateTime.Parse(row["Update_at"]),
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
                b => b.PropertyName == expectedPropertyDetails["PropertyName"]
                && b.Avatar == expectedPropertyDetails["Avatar"]
                && b.Images == expectedPropertyDetails["Images"]
                && b.PropertyType_ID == int.Parse(expectedPropertyDetails["PropertyType_ID"])
                && b.Content == expectedPropertyDetails["Content"]
                && b.Street_ID == int.Parse(expectedPropertyDetails["Street_ID"])
                && b.Ward_ID == int.Parse(expectedPropertyDetails["Ward_ID"])
                && b.District_ID == int.Parse(expectedPropertyDetails["District_ID"])
                && b.Price == int.Parse(expectedPropertyDetails["Price"])
                && b.UnitPrice == expectedPropertyDetails["UnitPrice"]
                && b.Area == expectedPropertyDetails["Area"]
                && b.BedRoom == int.Parse(expectedPropertyDetails["BedRoom"])
                && b.BathRoom == int.Parse(expectedPropertyDetails["BathRoom"])
                && b.PackingPlace == int.Parse(expectedPropertyDetails["PackingPlace"])
                && b.Create_post == DateTime.Parse(expectedPropertyDetails["Create_post"]));
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
