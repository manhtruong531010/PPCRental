using System.Collections.Generic;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BĐS.AcceptanceTests.Support
{
    public class ReferenceProjectList : Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string projectId)
        {
            return this[projectId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }
    }
}
