using System;
using UnityEngine;
using System.Collections;


namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of EntityFactory that creates lights in the scene.
    /// </summary>
	public class LightFactory : EntityFactory
	{
        /// <summary>
        /// Method builds a light GameObject and places it in an Entity. 
        /// </summary>
        /// <param name="list">List specifying how the Entity should be built.</param>
        /// <returns>A new Entity containing a new GameObject.</returns>
		public override Entity build(String[] list) //Light, EntityLink, type, #colour, xpos, ypos, zpos, range, intensity 
        {
            if (list == null) throw new ArgumentNullException("list", "The list of parameters to be built cannot be null.");
            if (list.Length != 9) throw new InvalidListLengthException(); 
            if (list[2] != "spot" && list[2] != "area" && list[2] != "directional" && list[2] != "point" && list[2] != "ambient") 
                throw new LightTypeNotFoundException();
            
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
            lightGameObject.transform.position = new Vector3(x, y, z);
            lightComponent.range = float.Parse(list[7]); 
            lightComponent.intensity = float.Parse(list[8]); 

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
        public override Entity buildBasic(string type, string entityLink, string button)
        {
            if (entityLink == null) throw new ArgumentNullException("entityLink", "The light must have a name.");
            if (type == null) throw new ArgumentNullException("type", "A light type must be specified.");
            if (type != "spot" && type != "area" && type != "directional" && type != "point")
                throw new LightTypeNotFoundException();
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