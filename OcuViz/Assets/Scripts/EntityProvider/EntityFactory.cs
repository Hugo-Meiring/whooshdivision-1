using System;
using System.Collections;
using UnityEngine;

namespace EntityProvider
{
	abstract class EntityFactory
	{
		
		public String typeName;
		
		public abstract Entity build(string[] list);

        public abstract Entity buildBasic(string button, string entityLink, string type);
	}
}
