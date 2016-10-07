using System;
using System.Collections.Generic;

namespace EntityProvider
{
    /// <summary>
    /// This class handles the creation and retrievals of EntityFactories
    /// as other classes may request. It treats all individual concrete
    /// EntityFactories as Singletons and only creates one. Outside classes
    /// should simply request a Factory without knowledge of its existence.
    /// </summary>
	public class FactoryShop
	{
        /// <summary>
        /// The pool of created EntityFactories. This pool should be queried
        /// for a factory and return if found, else create a new one and
        /// store it.
        /// </summary>
		private List<EntityFactory> factoryPool;

        /// <summary>
        /// Strings of factory names associated with their indices in the 
        /// factory pool. If a string is not found, then the Factory does
        /// not exist.
        /// </summary>
        private List<string> factoryIndices;

        /// <summary>
        /// Definition of a pointer to the current Factory instance to be 
        /// returned after getFactory() has executed.
        /// </summary>
        private EntityFactory currentFactory;

        /// <summary>
        /// Constructor. It creates a new factory pool and the corresponding
        /// string indices.
        /// </summary>
        public FactoryShop()
        {
            factoryIndices = new List<string>();
            factoryPool = new List<EntityFactory>();
        }
		
        /// <summary>
        /// Returns the instance of the factory requested from the factory pool.
        /// If the factory is not found, a new instance is created, added to the
        /// pool, and returned.
        /// </summary>
        /// <param name="typeName">Name of the Entity produced by the Factory.
        /// </param>
        /// <returns>Requested EntityFactory.</returns>
		public EntityFactory getFactory(String typeName)
        {
            for(int i = 0; i < factoryIndices.Count; ++i)
            {
                if (typeName == factoryIndices[i]) return factoryPool[i];
            }

            if(typeName == "Collection")
            {
                factoryIndices.Add(typeName);
                currentFactory = new CollectionFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            if(typeName == "CustomCollection")
            {
                factoryIndices.Add(typeName);
                currentFactory = new CustomCollectionFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            if(typeName == "Light")
            {
                factoryIndices.Add(typeName);
                currentFactory = new LightFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            if (typeName == "Model")
            {
                factoryIndices.Add(typeName);
                currentFactory = new ModelFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            if (typeName == "Shape")
            {
                factoryIndices.Add(typeName);
                currentFactory = new ShapeFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            if (typeName == "Viewer")
            {
                factoryIndices.Add(typeName);
                currentFactory = new ViewerFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            throw new ArgumentException(typeName + " not found");
        }
	}
	
}