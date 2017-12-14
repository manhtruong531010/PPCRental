using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BĐS.AcceptanceTests.Common
{
    public class ViewDetailsAssertions
    {
        public static void FoundDetailsHeadTitles(IEnumerable<PROPERTY> ViewDetails, IEnumerable<string> expectedTitles)
        {
            ViewDetails.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedTitles);
        }
    }
}
