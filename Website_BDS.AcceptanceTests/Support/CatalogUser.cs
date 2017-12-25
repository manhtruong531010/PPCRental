using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Website_BDS.AcceptanceTests.Support
{
public class CatalogUser
    {
        public CatalogUser()
        {
            ReferenceUser = new ReferenceUserList();
        }

        public ReferenceUserList ReferenceUser { get; set; }
    }
}
