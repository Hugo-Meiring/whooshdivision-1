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
            if (list.Length != 5) throw new InvalidListLengthException();

            GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject viewer = new GameObject();
            GameObject userController = new GameObject();
            Component[] userChildren;
            Component[] vrChildren;
            Component vrCamera = new Component();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "RigidBodyFPSController")
                {
                    viewer = rootObjects[i];
                }
                if (rootObjects[i].name == "UserController")
                {
                    userController = rootObjects[i];
                    userChildren = rootObjects[i].GetComponentsInChildren<MonoBehaviour>();
                    for (int j = 0; j < userChildren.Length; ++j)
                    {
                        if (userChildren[j].name == "VRLeapController")
                        {
                            vrChildren = userChildren[j].GetComponentsInChildren<MonoBehaviour>();
                            for (int k = 0; k < vrChildren.Length; ++k)
                            {
                                if (vrChildren[k].name == "CenterEyeAnchor")
                                {
                                    vrCamera = vrChildren[k];
                                }
                            }
                        }
                    }
                }
            }

            viewer.transform.position = new Vector3(float.Parse(list[1]), float.Parse(list[2]), float.Parse(list[3])); 
            viewer.transform.Rotate(0, float.Parse(list[4]), 0);

            userController.transform.position = new Vector3(float.Parse(list[1]), float.Parse(list[2]), float.Parse(list[3]));
            userController.transform.Rotate(0, float.Parse(list[4]), 0);

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
            Component[] userChildren;
            Component[] vrChildren;
            Component vrCamera = new Component();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "RigidBodyFPSController")
                {
                    viewer = rootObjects[i];
                }
                if (rootObjects[i].name == "UserController")
                {
                    userChildren = rootObjects[i].GetComponentsInChildren<MonoBehaviour>();
                    for (int j = 0; j < userChildren.Length; ++j)
                    {
                        if (userChildren[j].name == "VRLeapController")
                        {
                            vrChildren = userChildren[j].GetComponentsInChildren<MonoBehaviour>();
                            for (int k = 0; k < vrChildren.Length; ++k)
                            {
                                if (vrChildren[k].name == "CenterEyeAnchor")
                                {
                                    vrCamera = vrChildren[k];
                                }
                            }
                        }
                    }
                }
            }

            Entity entity = new Entity();
            entity.setName("viewer");
            entity.setGameObject(viewer);

            return entity;
        }
    }
}
