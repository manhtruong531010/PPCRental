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
    public class ProjectDriver
    {
        
        private readonly CatalogContext _context;

        //public ProjectDriver(SearchResultState result)
        //{
        //    _result = result;
        //}

        public ProjectDriver(CatalogContext context)
        {
            _context = context;
        }

        public void InsertProjecttoDB(Table givenProjects)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Avatar = row["Avarta"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = int.Parse(row["PropertyType"]),
                        Street_ID = int.Parse( row["Street"]),
                        Ward_ID = int.Parse( row["Ward"]),
                        District_ID = int.Parse(row["District"]),
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = int.Parse(row["UserID"]),
                        Created_at = Convert.ToDateTime(row["Create_at"]),
                        Create_post = Convert.ToDateTime(row["Create_post"]),
                        Status_ID = int.Parse(row["Status"]),
                        Note = row["Note"],
                        Updated_at = Convert.ToDateTime(row["Update_at"]),
                        Sale_ID = int.Parse(row["Sale_ID"])
                    };

                    _context.ReferenceProperty.Add(
                        givenProjects.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }


      
    }
}
