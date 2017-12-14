namespace Website_BĐS.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceProperty = new ReferenceProjectList();
        }

        public ReferenceProjectList ReferenceProperty { get; set; }
    }
}
