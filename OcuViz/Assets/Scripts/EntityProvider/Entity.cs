using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace EntityProvider
{
    /// <summary>
    /// This class is used to encapsulate and extend the functionality and services of a GameObject in Unity.
    /// An Entity must then have at least one GameObject to extend. GameObjects may not be worked on directly,
    /// but should rather use an Entity to do operations.
    /// </summary>
	public class Entity
	{
        /// <summary>
        /// The name of the Entity. This is always required. The name should be shared with the GameObject.
        /// </summary>
		private string name;

        /// <summary>
        /// The name of the parent Entity in the hierachy of the scene.
        /// </summary>
		private Entity parent;

        /// <summary>
        /// GameObject being encapsulated. This is what will be rendered in the final scene.
        /// </summary>
		private GameObject obj;

        //public Entity(Entity other)
        //{
        //    this.name = other.name;
        //    //this.parent = other.parent;   risks duplication. Plus the entity has already been created in a tree structure.
        //    this.obj = new GameObject(other.obj);
        //    this.obj = new GameObject(other.obj.name);
        //}
		
        /// <summary>
        /// Method is used to specify the name of the Entity.
        /// </summary>
        /// <param name="name">Name of the Entity.</param>
		public void setName(String name)
		{
            if (name == null)
                throw new NullReferenceException("Name of Entity is null.");
            else this.name = name;		
		}
		
        /// <summary>
        /// This method is used to set the GameObject of the Entity.
        /// If the GameObject is null, a NullReferenceException must be thrown.
        /// </summary>
        /// <param name="obj">Reference to the GameObject</param>
		public void setGameObject(GameObject obj)
		{
            if (obj != null)
            {
                this.obj = obj;
                if (this.obj.GetComponent<Renderer>() == null) this.obj.AddComponent<MeshRenderer>();
            }
            if (obj == null)
            {
                throw new NullReferenceException("Game object being set in Entity is null.");
            }
		}
		
        /// <summary>
        /// Sets the parent Entity of this current Entity.
        /// </summary>
        /// <param name="parent">Reference to the parent Entity.</param>
		public void setParent(Entity parent)
		{
			this.parent = parent;
		}
		
        /// <summary>
        /// Method is used to return the name of the Entity.
        /// </summary>
        /// <returns>This Entity's name.</returns>
		public String getName()
		{
			return this.name;
		}
		
        /// <summary>
        /// Method returns the GameObject in the Entity.
        /// </summary>
        /// <returns>GameObject within the Entity.</returns>
		public GameObject getGameObject()
		{
			return this.obj;
		}

        /// <summary>
        /// Returns the parent of the Entity.
        /// </summary>
        /// <returns>Entity's parent Entity.</returns>
		public Entity getParent()
		{
			return this.parent;
		}


        /// <summary>
        /// Method adds colour to the GameObjects in the Entity.
        /// </summary>
        /// <param name="colour">Colour object to be added to the GameObject.</param>
        public void addColour(Colour colour)
        {
            if (colour != null)
            {
                if (obj.GetComponent<Renderer>() == null) obj.AddComponent<MeshRenderer>();
                obj.GetComponent<Renderer>().material.color = colour.getColour();
            }
            if (colour == null) throw new NullReferenceException("Colour being set to Entity is null.");
        }

        /// <summary>
        /// Method adds texture to the GameObject in the Entity.
        /// </summary>
        /// <param name="path">The location of the texture to be added.</param>
        /// <param name="bumpMap">Indicates whether bump mapping should be enabled or not.</param>
        public void addTexture(string path, bool bumpMap)
        {
            if (obj.GetComponent<Renderer>() == null) obj.AddComponent<MeshRenderer>();
            Texture2D texture = new Texture2D(1, 1);
            if (path.Contains("http://") || path.Contains("https://") || path.Contains("www."))
            {
                WWW www = new WWW(path);
                //yield return www;
                texture = www.texture;
            }
            else
            {
                byte[] data = File.ReadAllBytes(path);
                texture.LoadImage(data);
            }

            if (texture != null)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.white;
                obj.GetComponent<MeshRenderer>().material.mainTexture = texture;
            }
            if (texture == null) throw new NullReferenceException("Texture was null. Check the filepath.");
        }

        /// <summary>
        /// Method to handle additional attributes. This is useful if subclassing Entity is necessary.
        /// </summary>
        /// <param name="attributes">List of additional attributes.</param>
        public virtual void handleAttributes(string[] attributes)
        {
            //tokenise
        }
	}
}
