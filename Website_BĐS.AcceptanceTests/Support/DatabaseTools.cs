using Website_BĐS.Models;
using TechTalk.SpecFlow;

namespace Website_BĐS.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new Team33Entities())
            {
                //db.OrderLines.RemoveRange(db.OrderLines);
                //db.Orders.RemoveRange(db.Orders);
                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.SaveChanges();
            }
        }
    }
}
