namespace Website_BĐS.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            Reference = new ReferenceProjectList();
        }

        public ReferenceProjectList ReferenceBooks { get; set; }
    }
}
