using System;
using UnityEngine;
using System.Collections;
using EntityProvider;

namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of EntityFactory that creates and handles collections of a
    /// predefined Entity. Collections are a composite of Entities. 
    /// </summary>
	public class CollectionFactory : EntityFactory
	{
        /// <summary>
        /// Builds a collection of Entities based on parameters. A prototype Entity needs to exist
        /// in the pool beforehand.
        /// </summary>
        /// <param name="list">List of parameters to specify creation of collection properties</param>
        /// <returns>A new collection.</returns>
		public override Entity build(String[] list)
		{
            if (list == null) throw new ArgumentNullException("list", "The list passed to build collection is null.");
            if (list.Length != 7) throw new InvalidListLengthException();
            Collection collection = new Collection();
            collection.setName(list[1] + " " + list[2] + " collection");
            collection.setType(list[2]);
            collection.setDimension(uint.Parse(list[3]));
            collection.setPos(float.Parse(list[4]), float.Parse(list[5]), float.Parse(list[6]));

            return collection;
        }
        /// <summary>
        /// Creates a single-Entity collection.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Collection's Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>Basic functional Collection</returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            if (entityLink == null) throw new ArgumentNullException("entityLink", "The entity link cannot be null.");
            if (type == null) throw new ArgumentNullException("type", "The collection type cannot be null.");
            Collection collection = new Collection();
            collection.setName(entityLink + " " + type + " collection");
            collection.setType(type);
            collection.setDimension(1);
            collection.setPos(0, 0, 0);

            return collection;
        }
    }
}
