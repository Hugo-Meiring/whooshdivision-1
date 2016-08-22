using System;
using UnityEngine;
using System.Collections;


namespace EntityProvider
{
	class LightFactory : EntityFactory
	{
		public override Entity build(String[] list)
		{
			typeName = list[0];
			GameObject lightGameObject = new GameObject(list[1]);
			Light lightComponent = lightGameObject.AddComponent<Light>();
            Colour color = new Colour(list[1], list[3]);
			lightComponent.color = color.getColour();
            if (list[2] == "spot") lightComponent.type = LightType.Spot;
            else if (list[2] == "area") lightComponent.type = LightType.Area;
            else if (list[2] == "directional") lightComponent.type = LightType.Directional;
            else if (list[2] == "point") lightComponent.type = LightType.Point;
			int x = int.Parse(list[4]);
			int y = int.Parse(list[5]);
			int z = int.Parse(list[6]);
			lightGameObject.transform.position = new Vector3(x,y,z);
			lightComponent.range = float.Parse(list[7]);
			lightComponent.intensity = float.Parse(list[8]);

            Entity newEntity = new Entity();
            newEntity.setName(list[1]);
            newEntity.setGameObject(lightGameObject);

			
			return newEntity; 
		}
	}
}