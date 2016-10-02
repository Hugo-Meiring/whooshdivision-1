using System;
using UnityEngine;

namespace EntityProvider
{
    class ModelFactory : EntityFactory
    {
        public ModelFactory()
        {
        }


        public override Entity build(String[] list)
        {
            typeName = list[0];
            Mesh mesh = new Mesh();
            //ObjImporter newMesh = new ObjImporter();
            //mesh = newMesh.ImportFile(list[3]);

            GameObject modelGameObject = new GameObject(list[1]);
            //MeshRenderer renderer = modelGameObject.AddComponent<MeshFilter>();
            modelGameObject.GetComponent<MeshFilter>().mesh = mesh;

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
