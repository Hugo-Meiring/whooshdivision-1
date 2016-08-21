using System;
using UnityEngine;
using System.Collections.Generic;

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

        public void addColour(Colour colour)
        {
            obj.GetComponent<Renderer>().material.color = colour.getColour();
        }

        public void addTexture(string path, bool bumpMap)
        {
            Texture2D texture = (Texture2D)Resources.Load(path) as Texture2D;
            //accesss renderer
            obj.GetComponent<Renderer>().material.mainTexture = texture;
        }

        public virtual void handleAttributes(List<string> attributes)
        {
            //tokenise
        }
	}
}
