using System;
using System.Collections.Generic;

namespace EntityProvider
{
    /// <summary>
    /// A concrete implementation of the EntityPool interface based on the List generic.
    /// <seealso cref="EntityPool"/>
    /// </summary>
    public class ConcreteEntityPool : EntityPool
    {
        //<value> A private member List used to storage utility to class functions.</value>
        private List<Entity> pool = new List<Entity>();
        
        /// <summary>
        /// A concrete implementation of the store method defined in the EntityPool interface.
        /// Adds an entity to the entity pool if it is not already present, otherwise raises a DuplicateEntityException.
        /// <seealso cref="DuplicateEntityException"/>
        /// <seealso cref="EntityPool.store"/>
        /// </summary>
        public void store(Entity entity) 
        {
            if (this.indexOf(entity.getName()) == -1)
                pool.Add(entity);
            else
                throw new DuplicateEntityException();
        }

        /// <summary>
        /// A concrete implementation of the fetch method defined in the EntityPool interface.
        /// Returns a referemce to the entity identified by entityName if such an entity exists, otherwise raises an EntityNotFoundException.
        /// <seealso cref="EntityNotFoundException"/>
        /// <seealso cref="EntityPool.fetch"/>
        /// </summary>
        public Entity fetch(string entityName) 
        {
            int index = this.indexOf(entityName);
            if (index >= 0)
                return pool[index];
            else
                throw new EntityNotFoundException();
        }

        /// <summary>
        /// Returns the index of the entity identified by entityName. If no such entity is found, -1 is returned.
        /// </summary>
        public int indexOf(string entityName)
        {
            return pool.FindIndex(x => x.getName() == entityName);
        }

        /// <summary>
        /// Returns the entity at the specified index. If the index is invalid, an exception is thrown.
        /// </summary>
        /// <param name="index">The integer specifying entity to be returned</param>
        /// <returns>Found Entity</returns>
        public Entity get(int index)
        {
            if (index < pool.Count && index >= 0) return pool[index];
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Removes the entity passed as a parameter from the pool.
        /// </summary>
        /// <param name="entity">
        /// Entity reference to be removed.
        /// </param>
        public void remove(Entity entity)
        {
            if (pool.Contains(entity))
            {
                pool.Remove(entity);
            }
            else throw new EntityNotFoundException();
        }

        /// <summary>
        /// Retuns the size of the entity pool.
        /// </summary>
        /// <returns>Entity pool size.</returns>
        public int size()
        {
            return pool.Count;
        }
    }
}