using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website_BĐS.Models;
using System.Data;
using Website_BDS.AcceptanceTests.Support;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Website_BDS.AcceptanceTests.Drivers.Property
{
			public class PropertyDriver
			{
			    Team33Entities db = new Team33Entities();
				private readonly CatalogContext _context;
				private readonly CatalogUser _contextEmail;
                //private ActionResult _result;	
            
				public PropertyDriver(CatalogContext context)
                {
                 _context = context;
                }
                public void InsertUserToDB(Table User)					
                {								
                using (db)
                {
                var dataTable = TableExtensions.ToDataTable(User);								
                foreach (var row in User.Rows)
                {
                    string Email = row["Email"];
                    string userID = row["UserID"];
                    string Password = row["Password"];
                    string FullName = row["FullName"];
                    string Phone = row["Phone"];
                    string Address = row["Address"];																
                    var user = new USER
                    {
                        Email = row["Email"],
                        Password = row["Password"],
                        FullName = row["FullName"],
                        Phone = row["Phone"],
                        Address = row["Address"],

                    };
                    _contextEmail.ReferenceUser.Add(
                             User.Header.Contains("ID") ? row["ID"] : user.Email,
                             user);

                    db.USERs.Add(user);
                }
                db.SaveChanges();
            }
        }
						
		}
}
