using System;

namespace EntityProvider
{
	abstract class FactoryShop
	{
		public EntityFactory[] factoryPool;
		
		public abstract EntityFactory getFactory(String typeName);
	}
	
}