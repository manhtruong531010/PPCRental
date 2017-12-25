using System.Collections.Generic;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BDS.AcceptanceTests.Support
{
 public class ReferenceUserList : Dictionary<string, USER>
    {
        public USER GetById(string Email)
        {
            return this[Email.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<USER>().Which;
        }
    }
}
