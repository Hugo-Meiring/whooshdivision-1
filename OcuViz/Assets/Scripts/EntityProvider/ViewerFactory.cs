using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
