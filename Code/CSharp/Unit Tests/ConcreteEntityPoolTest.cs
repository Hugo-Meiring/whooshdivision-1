using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityProvider;

namespace EntityProviderTests
{
    [TestClass]
    public class ConcreteEntityPoolTest
    {
        [TestMethod]
        public void indexOf_NotFound_ReturnsInvalidIndex()
        {
            int expected = -1;

            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            int actual = ce_pool.indexOf("notfound");

            Assert.areEqual(expected, actual, "Index of -1 is not returned when a nonexistent entity is searched for.");
        }
    }
}