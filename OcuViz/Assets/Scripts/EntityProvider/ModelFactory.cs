using System;
using UnityEngine;

namespace EntityProvider
{
    public class ModelFactory : EntityFactory
    {
        public ModelFactory()
        {
        }


        public override Entity build(String[] list)
        {
            if (list == null) throw new ArgumentNullException("list", "The list of parameters to be built cannot be null.");
            if (list.Length != 9) throw new InvalidListLengthException();
            typeName = list[0];
            Mesh mesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            mesh = newMesh.ImportFile(list[2]);

            GameObject modelGameObject = new GameObject(list[1]);
            MeshFilter renderer = modelGameObject.AddComponent<MeshFilter>();
            modelGameObject.AddComponent<MeshRenderer>();
            modelGameObject.AddComponent<SkinnedMeshRenderer>();
            modelGameObject.AddComponent<Rigidbody>();
            //modelGameObject.AddComponent<Phy>();
            modelGameObject.GetComponent<MeshFilter>().mesh = mesh;

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
            
            throw new NotImplementedException();
        }
    }
}
