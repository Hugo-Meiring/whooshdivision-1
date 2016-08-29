using System;
using UnityEngine;
using System.Collections.Generic;

namespace EntityProvider
{
	class Entity
	{
		private string name;
		private Entity parent;
		private GameObject obj;

        //public Entity(Entity other)
        //{
        //    this.name = other.name;
        //    //this.parent = other.parent;   risks duplication. Plus the entity has already been created in a tree structure.
        //    this.obj = new GameObject(other.obj);
        //    this.obj = new GameObject(other.obj.name);
        //}
		
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

        public virtual void handleAttributes(string[] attributes)
        {
            //tokenise
        }
	}
}
