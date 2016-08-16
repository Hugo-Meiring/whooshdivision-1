using System;
using UnityEngine;
using System.Collections;

namespace EntityProvider
{
	class CollectionFactory : EntityFactory
	{
		public override GameObject build(String[] list)
		{
            return new GameObject();
		}
		
	}
}
