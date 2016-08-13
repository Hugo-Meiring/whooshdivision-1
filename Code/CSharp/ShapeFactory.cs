using UnityEngine;
using System.Collections;

namespace EntityProvider
{
	class ShapeFactory
	{
		public GameObject build(String[] list)
		{
			typeName = list[0];
			bool flag = bool.Parse(list[4]);
			if(flag)
			{
				int x = int.Parse(list[6]);
				int y = int.Parse(list[7]);
				int z = int.Parse(list[8]);
				if(list[3] == "plane")
				{
					GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
					plane.transform.postion = new Vector3(x,y,z);
					entityPool.Add(plane);
					return plane;
					
				}	
				else if(list[3] == "cube")
				{
					GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.postion = new Vector3(x,y,z);
					entityPool.Add(cube);
					return cube;
					
				}	
				else if(list[3] == "sphere")
				{
					GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					sphere.transform.postion = new Vector3(x,y,z);
					entityPool.Add(sphere);
					return sphere;
					
				}	
				else if(list[3] == "capsule")
				{
					GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
					capsule.transform.postion = new Vector3(x,y,z);
					entityPool.Add(capsule);
					return capsule;
					
				}	
				else if(list[3] == "cylinder")
				{
					GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
					cylinder.transform.postion = new Vector3(x,y,z);
					entityPool.Add(cylinder);
					return cylinder;
					
				}	
				else if(list[3] == "quad")
				{
					GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
					quad.transform.postion = new Vector3(x,y,z);
					entityPool.Add(quad);
					return quad;
					
				}
			}
			else
			{
				int x = int.Parse(list[6]);
				int y = int.Parse(list[7]);
				
				if(list[3] == "triangle")
				{
				}
				
				else if(list[3] == "square" || list[3] == "rectangle")
				{
				}
				
				else if(list[3] == "cycle")
				{
				}
			}
		}
	}
