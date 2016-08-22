using System;
using System.Collections.Generic;

namespace EntityProvider
{
    class ConcreteEntityPool : EntityPool
    {
        private List<Entity> pool = new List<Entity>();
        
        public void store(Entity entity) 
        {
            if (this.indexOf(entity.getName()) == -1)
                pool.add(entity);
            else
                throw new DuplicateEntityException();
        }

        public void fetch(string entityName) 
        {
            int index = this.indexOf(entityName);
            if (index >= 0)
                return pool[index];
            else
                throw new EntityNotFoundException();
        }

        private int indexOf(string entityName)
        {
            Predicate<Entity> predicate = (Entity e) => {return e.getName() == entityName;};
            return pool.findIndex(predicate);
        }
    }
}