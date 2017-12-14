using System;
using System.Linq;
using System.Web.Mvc;
using Website_BĐS.Models;
using BookShop.AcceptanceTests.Support;
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
        
        public void InsertBookToDB(Table Books)
        {
            using (var db = new DatabaseContext())
            {
                foreach (var row in Books.Rows)
                {
                    var book = new Book
                    {
                        Author = row["Author"],
                        Title = row["Title"],
                        Price = Books.Header.Contains("Price")
                            ? Convert.ToDecimal(row["Price"])
                            : BookDefaultPrice
                    };

                    _context.ReferenceBooks.Add(
                            Books.Header.Contains("Id") ? row["Id"] : book.Title,
                            book);

                    db.Books.Add(book);
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
