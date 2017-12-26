using System.Collections.Generic;
using System.Linq;
using Website_BĐS.Models;
using FluentAssertions;

namespace Website_BDS.AcceptanceTests.Common
{
    public class PropertyAssertions
    {
        public static void FoundPROPERTYsShouldMatchPropertyNames(IEnumerable<PROPERTY> foundPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            foundPROPERTYs.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedPropertyNames);
        }

        public static void FoundPROPERTYsShouldMatchPropertyNamesInOrder(IEnumerable<PROPERTY> foundPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            foundPROPERTYs.Select(b => b.PropertyName).Should().Equal(expectedPropertyNames);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownPROPERTYs, string expectedPropertyName)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().Contain(expectedPropertyName);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().Equal(expectedPropertyNames);
        }

        public static void HomeScreenShouldShowInOrder(IEnumerable<PROPERTY> shownPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().Equal(expectedPropertyNames);
        }
    }
}
