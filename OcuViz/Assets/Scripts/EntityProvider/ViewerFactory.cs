using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of EntityFactory that creates a custom first person character in the scene.
    /// This class must behave as a Singleton, as only one camera can be used in a scene.
    /// </summary>
    public class ViewerFactory: EntityFactory
    {
        /// <summary>
        /// Method changes the default first person character in the scene to the custom parameters passed.
        /// This method should not create a new viewer, but only edit the existing one.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public override Entity build(string[] list)
        {
            if (list == null) throw new ArgumentNullException();
            if (list.Length != 8) throw new InvalidListLengthException();

            GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject viewer = new GameObject();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "RigidBodyFPSController")
                {
                    viewer = rootObjects[i];
                }
            }

            viewer.transform.position = new Vector3(float.Parse(list[2]), float.Parse(list[3]), float.Parse(list[4]));
            viewer.transform.Rotate(float.Parse(list[5]), float.Parse(list[6]), float.Parse(list[7]));

            Entity entity = new Entity();
            entity.setName(list[1]);
            entity.setGameObject(viewer);

            return entity;
        }

        /// <summary>
        /// Returns a handle to the camera in the scene to edit. This method should not create a new instance
        /// of a camera.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>The default viewer in the scene.</returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            if (entityLink == null) throw new ArgumentNullException("entityLink", "The entity must have a name");

            GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject viewer = new GameObject();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "RigidBodyFPSController")
                {
                    viewer = rootObjects[i];
                }
            }

            Entity entity = new Entity();
            entity.setName(entityLink);
            entity.setGameObject(viewer);

            return entity;
        }
    }
}
