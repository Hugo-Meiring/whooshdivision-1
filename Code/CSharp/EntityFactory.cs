using System;
using System.Collections;
using UnityEngine;

namespace EntityProvider
{
	abstract class EntityFactory
	{
		public List<GameObject> entityPool = new List<GameObject>()s;
		public String typeName;
		
		public abstract GameObject build(String[] list);
	}
}