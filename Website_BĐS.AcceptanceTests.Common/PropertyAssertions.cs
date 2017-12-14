using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BĐS.AcceptanceTests.Common
{
    public class PropertyAssertions
    {
        public static void FoundPropertyShouldMatchTitles(IEnumerable<PROPERTY> foundProperty, IEnumerable<string> expectedTitles)
        {
            foundProperty.Select(x => x.PropertyName).Should().Contain(expectedTitles);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownBooks, IEnumerable<string> expectedTitle)
        {
            shownBooks.Select(b => b.PropertyName).Should().Contain(expectedTitle);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> ShownName, TechTalk.SpecFlow.Table expectednameList)
        {
            throw new NotImplementedException();
        }
    }
}
