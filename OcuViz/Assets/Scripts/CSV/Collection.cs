using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EntityProvider
{
    class Collection: Entity //should be composite, as decorator needs Entity to be an interface. That wouldn't work too well.
    {
        private List<Entity> collection;
        private Entity original;
        private string type;
        private int dimension;
        private float xPos;
        private float yPos;
        private float zPos;

        public Collection()
        {
            collection = new List<Entity>();
        }

        public override void handleAttributes(string[] attributes)
        {

        }

        public List<Entity> createCollection() //Collection, EntityLink, type, 500, posX, posY, posZ
        {
            //handle transforms, etc.
            //EntityProvider.renderScene() will call this to delegate building the entities

            //todo: add separation of pieces (no overlapping if they spawn from the same place) <- gravity?
            //original.getGameObject().GetComponent<Rigidbody>().useGravity = true;

            if(type == "stack")
            {
                Entity spawn;
                //original.getGameObject().transform.position = new Vector3(xPos, yPos, zPos);

                for (int i = 0; i < dimension; ++i)
                {
                    //manually copy construct gameobject
                    //failed to get all components
                    UnityEngine.Object.Instantiate(original.getGameObject());
                    original.getGameObject().transform.position = new Vector3(xPos, yPos*i, zPos);
                }
            }
            else if(type == "random")
            {
                
            }
            else if(type == "row")
            {

            }
            return collection;
        }

        public void setEntity(Entity entity)
        {
            original = entity;
        }

        public void setType(string ty)
        {
            type = ty;
        }

        public void setDimension(int di)
        {
            dimension = di;
        }

        public void setPos(float x, float y, float z)
        {
            xPos = x;
            yPos = y;
            zPos = z;
        }
    }
}
