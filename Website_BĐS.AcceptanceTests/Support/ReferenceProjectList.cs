using System.Collections.Generic;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BĐS.AcceptanceTests.Support
{
    public class ReferenceProertyList : Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string propertyId)
        {
            return this[propertyId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }
    }
}
