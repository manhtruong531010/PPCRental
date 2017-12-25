using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Website_BDS.AcceptanceTests.Support
{
	public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceProperty = new ReferenceProertyList();
        }
      
        public ReferenceProertyList ReferenceProperty { get; set; }
    }
}
