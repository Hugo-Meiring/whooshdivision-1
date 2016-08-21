using System;
using System.Collections.Generic;

namespace EntityProvider
{
	class FactoryShop
	{
		private List<EntityFactory> factoryPool;
        private List<string> factoryIndices;
        private EntityFactory currentFactory;

        public FactoryShop()
        {
            factoryIndices = new List<string>();
            factoryPool = new List<EntityFactory>();
        }
		
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

            if(typeName == "Light")
            {
                factoryIndices.Add(typeName);
                currentFactory = new LightFactory();
                factoryPool.Add(currentFactory);
                return currentFactory;
            }

            //if (typeName == "Model")
            //{
            //    factoryIndices.Add(typeName);
            //    currentFactory = new ModelFactory();
            //    factoryPool.Add(currentFactory);
            //    return currentFactory;
            //}

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

            return null;
        }
	}
	
}