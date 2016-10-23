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
                temp = entityProvider.CreateGameObject("shape", "Cylinder", "cylinder");
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
                temp = entityProvider.CreateGameObject("collection", "ThreeD", "3d");

            }

            GameObject objCube = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            //objCube = entityProvider.CreateGameObject("shape", "Cube", "cube").getGameObject();
            temp.setGameObject(objCube);

            Collection newtemp = (Collection)temp;
            newtemp.setEntity(temp);
            newtemp.setDimension(10);
            //newtemp.setType("stack");
          //  newtemp.setGameObject(objCube);
            newtemp.createCollection();
           // placeEntity(temp);
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
           // placeEntity(temp);
            return temp;
        }
        public void setPlacement(string placement)
        {
            this.placement = placement;

        }
        public Entity getModel(string path)
        {
            
         
            Mesh mesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            mesh = newMesh.ImportFile(path);

            GameObject modelGameObject = new GameObject("model");
            MeshFilter renderer = modelGameObject.AddComponent<MeshFilter>();
            modelGameObject.AddComponent<MeshRenderer>();
            modelGameObject.AddComponent<SkinnedMeshRenderer>();
            modelGameObject.AddComponent<Rigidbody>();
            //modelGameObject.AddComponent<Phy>();
            modelGameObject.GetComponent<MeshFilter>().mesh = mesh;

            //modelGameObject.transform.position = new Vector3(), float.Parse(list[4]), float.Parse(list[5]));
           // modelGameObject.transform.localScale = new Vector3(float.Parse(list[6]), float.Parse(list[7]), float.Parse(list[8]));
            modelGameObject.GetComponent<Rigidbody>().useGravity = false;

            Entity entity = new Entity();
            entity.setName("model");
            entity.setGameObject(modelGameObject);

            return entity;

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

                    Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
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
