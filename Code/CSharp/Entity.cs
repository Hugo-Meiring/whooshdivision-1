using System;
using UnityEngine;

namespace EntityProvider
{
	class Entity
	{
		private String name;
		private Entity parent;
		private GameObject obj;
		
		public void setName(String name)
		{
		     this.name = name;		
		}
		
		public void setGameObject(GameObject obj)
		{
			this.obj = obj;
		}
		
		public void setParent(Entity parent)
		{
			this.parent = parent;
		}
		
		public String getName()
		{
			return this.name;
		}
		
		public GameObject getGameObject()
		{
			return this.obj;
		}
		public Entity getParent()
		{
			return this.parent;
		}
	}
}
