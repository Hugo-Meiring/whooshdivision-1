using System;

namespace EntityProvider
{
	class ModelFactory : EntityFactory
	{
		public ModelFactory()
		{
			public Entity build(String[] list)
			{
				typeName =  list[0];
				Mesh mesh  = new Mesh();
				ObjImporter newMesh = new ObjImpoter();
				mesh = newMesh.ImportFile(list[3]);
				
				GameObject modelGameObject = new GameObject(list[1]);
				MeshRenderer renderer = modelGameObject.AddComponent<MeshFilter>();
				filter.mesh = mesh;
				
				return modelGameObject;
	
				
				
			}
			
		}
	}
	
}
