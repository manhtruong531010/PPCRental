using System;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using Website_BĐS.AcceptanceTests.Support;
using Website_BĐS.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.BookDetails
{
    public class BookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context)
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

                    _context.ReferenceBooks.Add(
                         givenProjects.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                         property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void ShowBookDetails(Table shownBookDetails)
        {
            //Arrange
            var expectedBookDetails = shownBookDetails.Rows.Single();

            //Act
            var actualBookDetails = _result.Model<Book>();

            //Assert
            actualBookDetails.Should().Match<Book>(
                b => b.Title == expectedBookDetails["Title"]
                && b.Author == expectedBookDetails["Author"]
                && b.Price == decimal.Parse(expectedBookDetails["Price"]));
        }

        public void OpenBookDetails(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
            using (var controller = new CatalogController())
            {
                _result = controller.Details(book.Id);
            }
        }
    }
}
