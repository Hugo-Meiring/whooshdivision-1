using System;
using UnityEngine;
using System.Collections;


namespace EntityProvider
{
	class LightFactory : EntityFactory
	{
		public GameObject build(String[] list)
		{
			typeName = list[0];
			GameObject lightGameObject = new GameObject(list[1]);
			Light lightComponent = lightGameObject.AddComponent<Light>();
			lightComponent.color = list[3];
			lightComponent.type = list[2];
			int x = int.Parse(list[4]);
			int y = int.Parse(list[5]);
			int z = int.Parse(list[6]);
			lightGameObject.transform.position = new Vector3(x,y,z);
			lightComponent.range = float.Parse(list[7]);
			lightComponent.intensity = float.Parse(list[8]);
			entityPool.Add(lightGameObject);
			
			return lightGameObject;
		}
	}
}