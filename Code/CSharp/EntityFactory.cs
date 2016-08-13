using System;
using System.Collections;
using UnityEngine;

namespace EntityProvider
{
	abstract class EntityFactory
	{
		
		public String typeName;
		
		public abstract GameObject build(String[] list);
	}
}
