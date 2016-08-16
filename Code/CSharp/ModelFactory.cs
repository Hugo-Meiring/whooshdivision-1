using System;
using UnityEngine;

namespace EntityProvider
{
	class ModelFactory : EntityFactory
	{
		public ModelFactory()
		{
			public override GameObject build(String[] list)
			{
				typeName =  list[0];
				Mesh mesh  = new Mesh();
				ObjImporter newMesh = new ObjImporter();
				mesh = newMesh.ImportFile(list[3]);
				
				GameObject modelGameObject = new GameObject(list[1]);
				MeshRenderer renderer = modelGameObject.AddComponent<MeshFilter>();
				filter.mesh = mesh;
				
				return modelGameObject;
	
				
				
			}
			
		}
	}
	
}
