using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntityProvider
{
    /// <summary>
    /// Definition of a collection of Entities.The class extends Entity and also encapsulates Entities, therefore makes it
    /// composite. This class must have at least one Entity inside that will be rendered multiple times in the scene. This
    /// Entity needs to be predefined, else EntityNotFoundException must be thrown.
    /// </summary>
    public class Collection: Entity //should be composite, as decorator needs Entity to be an interface. That wouldn't work too well.
    {
        /// <summary>
        /// The collection of Entities.
        /// </summary>
        private List<Entity> collection;

        /// <summary>
        /// The original Entity to be cloned.
        /// </summary>
        private Entity original;

        /// <summary>
        /// String specifying the type of collection to be created. Possibilities are random, stack, row, 2D, and 3D.
        /// </summary>
        private string type;

        /// <summary>
        /// A multi-purpose integer used differently as required by the type of collection.
        /// <para>Random: dimension provides the number of total GameObjects to be placed in the scene.</para>
        /// <para>Stack: dimension provides the total number of GameObjects in the stack.</para>
        /// <para>Row: dimesion specifies the total size of the row of GameObjects.</para>
        /// <para>2D: dimension is used to determine the number of Entities in one axis. Therefore total number of GameObjects in
        /// a collection will be dimension^2</para>
        /// <para>3D: dimension is used to determine the number of Entities in one axis. Therefore total number of GameObjects in
        /// a collection will be dimension^3</para>
        /// </summary>
        private uint dimension;

        /// <summary>
        /// The values used to define the volume of the collection, or the starting point of the collection, depending on the type.
        /// </summary>
        private float xPos;
        private float yPos;
        private float zPos;

        /// <summary>
        /// The dimensions of the prototype Entity;
        /// </summary>
        private float xDim;
        private float yDim;
        private float zDim;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Collection()
        {
            collection = new List<Entity>();
        }

        /// <summary>
        /// Method used to handle additional attributes.
        /// </summary>
        /// <param name="attributes">Additional attributes list.</param>
        public override void handleAttributes(string[] attributes)
        {

        }

        /// <summary>
        /// Method used to create the collection. This method should only be called once all the necessary
        /// attributes have been handled and changed. It should also be called during render time as it 
        /// renders the collection into the scene.
        /// </summary>
        /// <returns>The collection rendered.</returns>
        public List<Entity> createCollection() //Collection, EntityLink, type, 500, posX, posY, posZ
        {
            GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject parent = new GameObject();

            for(int i = 0; i < roots.Length; ++i)
            {
                if(roots[i].name == "InteractionManager")
                {
                    parent = roots[i];
                }
            }

            if (type == "stack")
            {
                for (int i = 0; i < dimension; ++i)
                {
                    //manually copy construct gameobject
                    //failed to get all components
                    original.getGameObject().transform.SetParent(parent.transform);
                    original.getGameObject().transform.position = new Vector3(xPos, yPos + (i * yDim), zPos);
                    UnityEngine.Object.Instantiate(original.getGameObject());
                    
                }
            }
            else if (type == "random")
            {
                bool[][] taken = new bool[(int)Math.Abs(Math.Ceiling(xPos))][];
                for(int r = 0; r < (int)xPos; ++r)
                {
                    taken[r] = new bool[(int)Math.Abs(Math.Ceiling(zPos))];
                }
                
                for (int i = 0; i < dimension; ++i)
                {

                    original.getGameObject().transform.SetParent(parent.transform);
                    //do
                    //{
                    original.getGameObject().transform.position = new Vector3(UnityEngine.Random.Range((xPos < 0) ? xPos : 0, (xPos < 0) ? 0 : xPos),
                            UnityEngine.Random.Range((yPos < 0) ? yPos : 0, (yPos < 0) ? 0 : yPos),
                            UnityEngine.Random.Range((zPos < 0) ? zPos : 0, (zPos < 0) ? 0 : zPos));
                    //} while (!taken[(int)Math.Abs(original.getGameObject().transform.position.x)][(int)Math.Abs(original.getGameObject().transform.position.z)]);
                    UnityEngine.Object.Instantiate(original.getGameObject());
                    original.getGameObject().transform.SetParent(parent.transform);
                    //taken[(int)Math.Abs(original.getGameObject().transform.position.x)][(int)Math.Abs(original.getGameObject().transform.position.z)] = true;

                    //Vector3 vector;
                    //do
                    //{
                    //    vector = new Vector3(UnityEngine.Random.Range((xPos < 0) ? xPos : 0, (xPos < 0) ? 0 : xPos),
                    //        UnityEngine.Random.Range((yPos < 0) ? yPos : 0, (yPos < 0) ? 0 : yPos),
                    //        UnityEngine.Random.Range((zPos < 0) ? zPos : 0, (zPos < 0) ? 0 : zPos));
                    //    original.getGameObject().transform.position.Set(vector.x, vector.y, vector.z);
                    //} while (!taken[(int)Math.Abs(original.getGameObject().transform.position.x)][(int)Math.Abs(original.getGameObject().transform.position.z)]);
                    //UnityEngine.Object.Instantiate(original.getGameObject());
                    //taken[(int)Math.Abs(original.getGameObject().transform.position.x)][(int)Math.Abs(original.getGameObject().transform.position.z)] = true;
                }
            }
            else if (type == "row")
            {
                for (int i = 0; i < dimension; ++i)
                {
                    //manually copy construct gameobject
                    //failed to get all components
                    original.getGameObject().transform.position = new Vector3(xPos, yPos, zPos + (i * zDim));
                    UnityEngine.Object.Instantiate(original.getGameObject());
                }
            }

            else if (type == "2d")
            {
                for (int i = 0; i < dimension; ++i)
                {
                    for (int j = 0; j < dimension; ++j)
                    {
                        original.getGameObject().transform.position = new Vector3(xPos + (xDim * i), yPos, zPos + (zDim * j));
                        UnityEngine.Object.Instantiate(original.getGameObject());
                    }
                }
            }
            else if (type == "3d")
            {
                for (int k = 0; k < dimension; ++k)
                {
                    for (int i = 0; i < dimension; ++i)
                    {
                        for (int j = 0; j < dimension; ++j)
                        {
                            original.getGameObject().transform.position = new Vector3(xPos + (xDim * i), yPos + (yDim * k), zPos + (zDim * j));
                            UnityEngine.Object.Instantiate(original.getGameObject());
                            original.getGameObject().transform.SetParent(parent.transform);
                        }
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// Sets the Entity to be prototyped in the Collection. This must be set before rendering the collection.
        /// </summary>
        /// <param name="entity">Prototype reference.</param>
        public Entity setEntity(Entity entity)
        {
            if (entity != null)
            {
                original = entity;
                xDim = original.getGameObject().transform.localScale.x;
                yDim = original.getGameObject().transform.localScale.y;
                zDim = original.getGameObject().transform.localScale.z;
                
                return original;
            }
            else throw new ArgumentNullException("entity", "The entity into the collection is null");
        }

        /// <summary>
        /// Specifies the type of collection to be created.
        /// </summary>
        /// <param name="ty">String containing the collection type.</param>
        public string setType(string ty)
        {
            if (ty == null) throw new NullReferenceException("Name of collection type is null.");
            if (ty != "stack" && ty != "random" && ty != "row" && ty != "2d" && ty != "3d")
            {
                throw new CollectionTypeNotFoundException();
            }
            type = ty;
            return type;
        }

        /// <summary>
        /// Sets the dimension value to be used as specified above.
        /// </summary>
        /// <param name="di">int with dimension value.</param>
        public uint setDimension(uint di)
        {
            dimension = di;
            return dimension;
        }

        /// <summary>
        /// Method used to specify the volume of the collection, or starting position of the
        /// collection, depending on the collection's type.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        /// <param name="z">The z-axis value.</param>
        public void setPos(float x, float y, float z)
        {
            xPos = x;
            yPos = y;
            zPos = z;
        }

        /// <summary>
        /// Returns the type of collection.
        /// </summary>
        /// <returns>Collection type.</returns>
        public string getType()
        {
            return type;
        }
    }
}
