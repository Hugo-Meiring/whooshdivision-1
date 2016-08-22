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

        [TestMethod]
        public void indexOf_Found_ReturnsValidIndex()
        {
            int expected = 0;

            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            Entity foo = new Entity();
            foo.setname("found");
            ce_pool.store(foo);

            int actual = ce_pool.indexOf("foo");

            Assert.areEqual(expected, actual, "Correct index is not returned when a present entity is searched for.");
        }

        [TestMethod]
        public void store_NoDuplicates_StoresEntity()
        {
            int expected = 0;

            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            Entity foo = new Entity();
            foo.setname("added");
            ce_pool.store(foo);

            int actual = ce_pool.indexOf("foo");

            Assert.areEqual(expected, actual, "Entity is not added to the pool despite not being a duplicate.");
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntityException))]
        public void store_Duplicates_ThrowsException()
        {
            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            Entity foo = new Entity();
            Entity bar = new Entity();
            foo.setname("added");
            bar.setname("added");
            ce_pool.store(foo);
            ce_pool.store(bar);
        }
    }
}