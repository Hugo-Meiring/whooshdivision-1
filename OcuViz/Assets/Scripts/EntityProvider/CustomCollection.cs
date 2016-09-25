using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    class CustomCollection: Entity //posX, posY, posZ, dimX, dimY, dimZ, #colour
    {
        /// <summary>
        /// The default entity to be used in the collection. The CustomCollectionFactory
        /// should alter this Entity.
        /// </summary>
        private Entity original;

        /// <summary>
        /// The collection containing the individual custom entities to be rendered as 
        /// part of this collection.
        /// </summary>
        private List<Entity> collection;

        /// <summary>
        /// Method adds an Entity into the Collection.
        /// </summary>
        /// <param name="entity">Entity to be added to the Collection.</param>
        public void addEntity(Entity entity)
        {
            if(entity != null) collection.Add(entity);
        }
    }
}
