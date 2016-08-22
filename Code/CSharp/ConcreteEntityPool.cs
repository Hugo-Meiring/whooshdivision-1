using System;
using System.Collections.Generic;

namespace EntityProvider
{
    /// <summary>
    /// A concrete implementation of the EntityPool interface based on the List generic.
    /// <seealso cref="EntityPool"/>
    /// </summary>
    class ConcreteEntityPool : EntityPool
    {
        //<value> A private member List used to storage utility to class functions.</value>
        private List<Entity> pool = new List<Entity>();
        
        /// <summary>
        /// A concrete implementation of the store method defined in the EntityPool interface.
        /// Adds an entity to the entity pool if it is not already present, otherwise raises a DuplicateEntityException.
        /// <seealso cref="DuplicateEntityException"/>
        /// <seealso cref="EntityPool.store"/>
        /// </summary>
        public void store(ref Entity entity) 
        {
            if (this.indexOf(entity.getName()) == -1)
                pool.add(entity);
            else
                throw new DuplicateEntityException();
        }

        /// <summary>
        /// A concrete implementation of the fetch method defined in the EntityPool interface.
        /// Returns a referemce to the entity identified by entityName if such an entity exists, otherwise raises an EntityNotFoundException.
        /// <seealso cref="EntityNotFoundException"/>
        /// <seealso cref="EntityPool.fetch"/>
        /// </summary>
        public ref Entity fetch(ref string entityName) 
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
        public int indexOf(ref string entityName)
        {
            Predicate<Entity> predicate = (Entity e) => {return e.getName() == entityName;};
            return pool.findIndex(predicate);
        }
    }
}