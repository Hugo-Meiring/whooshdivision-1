using System;
using UnityEngine;

namespace EntityProvider
{
    public class ModelFactory : EntityFactory
    {
        public ModelFactory()
        {
        }


        public override Entity build(string[] list)
        {
            if (list == null) throw new ArgumentNullException("list", "The list of parameters to be built cannot be null.");
            if (list.Length != 9) throw new InvalidListLengthException();
            typeName = list[0];
            Mesh mesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            mesh = newMesh.ImportFile(list[2]);

            GameObject modelGameObject = new GameObject(list[1]);
            MeshFilter filter = modelGameObject.AddComponent<MeshFilter>();
            modelGameObject.AddComponent<MeshRenderer>();
            modelGameObject.AddComponent<SkinnedMeshRenderer>();
            //modelGameObject.AddComponent<Phy>();
            modelGameObject.GetComponent<MeshFilter>().mesh = mesh;
            modelGameObject.AddComponent<Rigidbody>();

            modelGameObject.GetComponent<Renderer>().material.color = Color.black;

            modelGameObject.transform.position = new Vector3(float.Parse(list[3]), float.Parse(list[4]), float.Parse(list[5]));
            modelGameObject.transform.localScale = new Vector3(float.Parse(list[6]), float.Parse(list[7]), float.Parse(list[8]));
            modelGameObject.GetComponent<Rigidbody>().useGravity = false;

            Entity entity = new Entity();
            entity.setName(list[1]);
            entity.setGameObject(modelGameObject);

            return entity;
        }

        public override Entity buildBasic(string button, string entityLink, string type)
        {

            if (button == null) throw new ArgumentNullException("button", "The button pressed cannot be null.");
            if (entityLink == null) throw new ArgumentNullException("entityLink", "The entityLink cannot be null.");
            if (type == null) throw new ArgumentNullException("type", "The type cannot be null.");
            typeName = "Model";
            Mesh mesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            mesh = newMesh.ImportFile(type);

            GameObject modelGameObject = new GameObject(entityLink);
            MeshFilter filter = modelGameObject.AddComponent<MeshFilter>();
            modelGameObject.AddComponent<MeshRenderer>();
            modelGameObject.AddComponent<SkinnedMeshRenderer>();
            //modelGameObject.AddComponent<Phy>();
            modelGameObject.GetComponent<MeshFilter>().mesh = mesh;
            modelGameObject.AddComponent<Rigidbody>();

            modelGameObject.GetComponent<Renderer>().material.color = Color.black;
            
            modelGameObject.transform.localScale = new Vector3(1, 1, 1);
            modelGameObject.GetComponent<Rigidbody>().useGravity = false;

            Entity entity = new Entity();
            entity.setName(entityLink);
            entity.setGameObject(modelGameObject);

            return entity;
        }
    }
}
