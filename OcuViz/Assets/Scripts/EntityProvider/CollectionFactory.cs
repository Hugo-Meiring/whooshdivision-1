using System;
using UnityEngine;
using System.Collections;

namespace EntityProvider
{
	class CollectionFactory : EntityFactory
	{
		public override Entity build(String[] list)
		{
            Collection collection = new Collection();
            collection.setName(list[1]);
            collection.setType(list[2]);
            collection.setDimension(int.Parse(list[3]));
            collection.setPos(float.Parse(list[4]), float.Parse(list[5]), float.Parse(list[6]));

            return collection;
        }

        public override Entity buildBasic(string button, string entityLink, string type)
        {
            Collection collection = new Collection();
            collection.setName(entityLink);
            collection.setType(type);
            collection.setDimension(1);
            collection.setPos(0, 0, 0);

            return collection;
        }
    }
}
