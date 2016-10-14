using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EntityProvider
{
    public class EditorEntity : MonoBehaviour
    {
        private EntityProvider entityProvider = new EntityProvider();
        private string placement = "Random";
        private List<Entity> entities = new List<Entity>();

        public Entity getShape(int selected)
        {
            Entity temp = new Entity();
            if (selected == 0)
            {
                temp = entityProvider.CreateGameObject("shape", "Cube", "cube");
            }
            else if (selected == 1)
            {
                temp = entityProvider.CreateGameObject("shape", "Sphere", "sphere");
            }
            else if (selected == 2)
            {
                temp = entityProvider.CreateGameObject("shape", "Capsule", "capsule");
            }
            else if (selected == 3)
            {
                temp = entityProvider.CreateGameObject("shape", "Cyclinder", "cyclinder");
            }
            else if (selected == 4)
            {
                temp = entityProvider.CreateGameObject("shape", "Plane", "plane");
            }
            else
            {
                temp = entityProvider.CreateGameObject("shape", "Quad", "quad");
            }

            placeEntity(temp);
            entities.Add(temp);
            return temp;
        }

        public Entity getCollection(int selected)
        {
            Entity temp = new Entity();
            if (selected == 0)
            {
                temp = entityProvider.CreateGameObject("collection", "Stack", "stack");
            }
            else if (selected == 1)
            {
                temp = entityProvider.CreateGameObject("collection", "Row", "row");
            }
            else if (selected == 2)
            {
                temp = entityProvider.CreateGameObject("collection", "Random", "random");

            }
            else
            {
                temp = entityProvider.CreateGameObject("collection", "ThreeD", "threeD");

            }
            placeEntity(temp);
            entities.Add(temp);
            return temp;
        }

        public Entity getLight(int selected)
        {
            Entity temp = new Entity();
            if (selected == 0)
            {
                temp = entityProvider.CreateGameObject("light", "Point", "point");

            }
            else if (selected == 1)
            {
                temp = entityProvider.CreateGameObject("light", "Spot", "spot");

            }
            else if (selected == 2)
            {
                temp = entityProvider.CreateGameObject("light", "Directional", "direction");
            }
            else
            {
                temp = entityProvider.CreateGameObject("light", "Area", "area");

            }

            entities.Add(temp);
            placeEntity(temp);
            return temp;
        }
        public void setPlacement(string placement)
        {
            this.placement = placement;

        }
        public Entity getModel(string path)
        {
            Entity temp = new Entity();
            temp = entityProvider.CreateGameObject("model", "Model", path);
            placeEntity(temp);
            entities.Add(temp);
            return temp;

        }

        public void placeEntity(Entity entity)
        {
            GameObject temp = entity.getGameObject();
            bool done = false;
            temp.AddComponent<SphereCollider>();
            if(placement == "Random")
            {
                while (!done)
                {
                    Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
                    float radius = temp.GetComponent<SphereCollider>().radius;
                    if (!(Physics.CheckSphere(position, radius)))
                    {
                        temp.transform.position = position;
                        done = true;
                    }
                }


             }
        }

    }
}
