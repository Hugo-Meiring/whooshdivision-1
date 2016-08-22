using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityProvider;

namespace EntityProviderTests
{
    /// <summary>
    /// A test class which contains unit tests to assess the correctness of the services provided by ConcreteEntityPool.
    /// <seealso cref="ConcreteEntityPool"/>
    /// </summary>
    [TestClass]
    public class ConcreteEntityPoolTest
    {
        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.indexOf returns a not-found index when calling it with an
        /// argument which indicates an entity which is not present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.indexOf"/>
        /// </summary>
        [TestMethod]
        public void indexOf_NotFound_ReturnsInvalidIndex()
        {
            int expected = -1;

            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            int actual = ce_pool.indexOf("notfound");

            Assert.areEqual(expected, actual, "Index of -1 is not returned when a nonexistent entity is searched for.");
        }

        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.indexOf returns a valid index when calling it with an
        /// argument which indicates an entity which is present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.indexOf"/>
        /// </summary>
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

        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.store correctly adds an entity to the pool when calling it with an
        /// argument  entity which is not present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.store"/>
        /// </summary>
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

        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.store correctly raises an exception when calling it with an
        /// argument  entity which is present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.store"/>
        /// <seealso cref="DuplicateEntityException"/>
        /// </summary>
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

        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.fetch correctly fetches an entity reference when calling it with an
        /// argument entity name which indicates an entity that is present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.fetch"/>
        /// </summary>
        [TestMethod]
        public void fetch_EntityExists_FetchesCorrectReference()
        {
            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            Entity foo = new Entity();
            foo.setname("added");
            ce_pool.store(foo);

            Entity actual = ce_pool.fetch("foo");

            Assert.areEqual(foo, actual, "Entity is not fetched despite being present.");
        }

        /// <summary>
        /// A unit test which checks whether ConcreteEntityPool.fetch correctly raises an exception when calling it with an
        /// argument entity name which indicates an entity that is not present in the EntityPool
        /// <seealso cref="ConcreteEntityPool.fetch"/>
        /// <seealso cref="EntityNotFoundException"/>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void fetch_EntityNotExist_ThrowsException()
        {
            ConcreteEntityPool ce_pool = new ConcreteEntityPool();
            Entity foo = ce_pool.fetch("notfound");
        }
    }
}