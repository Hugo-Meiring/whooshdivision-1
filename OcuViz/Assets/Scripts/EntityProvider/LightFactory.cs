using System;
using UnityEngine;
using System.Collections;


namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of EntityFactory that creates lights in the scene.
    /// </summary>
	class LightFactory : EntityFactory
	{
        /// <summary>
        /// Method builds a light GameObject and places it in an Entity. 
        /// </summary>
        /// <param name="list">List specifying how the Entity should be built.</param>
        /// <returns>A new Entity containing a new GameObject.</returns>
		public override Entity build(String[] list) //Light, EntityLink, parent, type, #colour, x, y, z, range, intensity
		{
			typeName = list[0];
			GameObject lightGameObject = new GameObject(list[1]);
			Light lightComponent = lightGameObject.AddComponent<Light>();
            Colour color = new Colour(list[1], list[4]);
			lightComponent.color = color.getColour();
            if (list[3] == "spot") lightComponent.type = LightType.Spot;
            else if (list[3] == "area") lightComponent.type = LightType.Area;
            else if (list[3] == "directional") lightComponent.type = LightType.Directional;
            else if (list[3] == "point") lightComponent.type = LightType.Point;
			int x = int.Parse(list[5]);
			int y = int.Parse(list[6]);
			int z = int.Parse(list[7]);
			lightGameObject.transform.position = new Vector3(x,y,z);
			lightComponent.range = float.Parse(list[8]);
			lightComponent.intensity = float.Parse(list[9]);

            Entity newEntity = new Entity();
            newEntity.setName(list[1]);
            newEntity.setGameObject(lightGameObject);

			
			return newEntity; 
		}

        /// <summary>
        /// Creates a white light with 1 km range and full intensity.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>Basic functional Light GameObject within an Entity.</returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            GameObject lightGameObject = new GameObject(entityLink);
            Light lightComponent = lightGameObject.AddComponent<Light>();
            Colour color = new Colour(entityLink, "#fff");
            lightComponent.color = color.getColour();
            if (type == "spot") lightComponent.type = LightType.Spot;
            else if (type == "area") lightComponent.type = LightType.Area;
            else if (type == "directional") lightComponent.type = LightType.Directional;
            else if (type == "point") lightComponent.type = LightType.Point;
            lightGameObject.transform.position = new Vector3(0, 0, 0);
            lightComponent.range = 1000;
            lightComponent.intensity = 1;

            Entity newEntity = new Entity();
            newEntity.setName(entityLink);
            newEntity.setGameObject(lightGameObject);


            return newEntity;
        }
    }
}