using Website_BĐS.Models;
using TechTalk.SpecFlow;
namespace Website_BDS.AcceptanceTests.Support
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
                db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE);
                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.USERs.RemoveRange(db.USERs);
                db.SaveChanges();
            }
        }
    }
}
