using UnityEngine;
using System.Collections;
using System;

namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of EntityFactory that creates shapes of GameObjects.
    /// </summary>
    public class ShapeFactory : EntityFactory
    {
        /// <summary>
        /// Method used to create a 2D and 3D shapes from a list of parameters.
        /// </summary>
        /// <param name="list">List of parameters used to specify the Entity.</param>
        /// <returns>Entity containing a shape GameObject.</returns>
        public override Entity build(string[] list) //Shape, EntityLink, parent, type, 3D_FLAG, USE_GRAVITY, mass, xlen, ylen[, zlen], xpos, ypos, zpos
        {
            if (list == null) throw new ArgumentNullException("list", "The list of parameters to be built cannot be null.");
            if (list.Length != 13) throw new InvalidListLengthException();
            Entity entity = new Entity();
            entity.setName(list[1]);
            typeName = list[0];
            bool flag = bool.Parse(list[4]);
            bool gravity = bool.Parse(list[5]);
            int mass = int.Parse(list[6]);
            if (flag)
            {
                float x = float.Parse(list[7]);
                float y = float.Parse(list[8]);
                float z = float.Parse(list[9]);

                float xPos = float.Parse(list[10]);
                float yPos = float.Parse(list[11]);
                float zPos = float.Parse(list[12]);

                if (list[3] == "plane")
                {
                    GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    plane.name = list[1];
                    plane.transform.localScale = new Vector3(x, y, z);
                    plane.transform.position = new Vector3(xPos, yPos, zPos);
                    plane.AddComponent<Rigidbody>();
                    plane.GetComponent<Rigidbody>().useGravity = gravity;
                    plane.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(plane);
                    return entity;

                }
                else if (list[3] == "cube")
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = list[1];
                    cube.transform.localScale = new Vector3(x, y, z);
                    cube.transform.position = new Vector3(xPos, yPos, zPos);
                    cube.AddComponent<Rigidbody>();
                    cube.GetComponent<Rigidbody>().useGravity = gravity;
                    cube.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cube);
                    return entity;

                }
                else if (list[3] == "sphere")
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.name = list[1];
                    sphere.transform.localScale = new Vector3(x, y, z);
                    sphere.transform.position = new Vector3(xPos, yPos, zPos);
                    sphere.AddComponent<Rigidbody>();
                    sphere.GetComponent<Rigidbody>().useGravity = gravity;
                    sphere.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(sphere);
                    return entity;

                }
                else if (list[3] == "capsule")
                {
                    GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    capsule.name = list[1];
                    capsule.transform.localScale = new Vector3(x, y, z);
                    capsule.transform.position = new Vector3(xPos, yPos, zPos);
                    capsule.AddComponent<Rigidbody>();
                    capsule.GetComponent<Rigidbody>().useGravity = gravity;
                    capsule.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(capsule);
                    return entity;

                }
                else if (list[3] == "cylinder")
                {
                    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    cylinder.name = list[1];
                    cylinder.transform.localScale = new Vector3(x, y, z);
                    cylinder.transform.position = new Vector3(xPos, yPos, zPos);
                    cylinder.AddComponent<Rigidbody>();
                    cylinder.GetComponent<Rigidbody>().useGravity = gravity;
                    cylinder.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cylinder);
                    return entity;

                }
                else if (list[3] == "quad")
                {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.name = list[1];
                    quad.transform.localScale = new Vector3(x, y, z);
                    quad.transform.position = new Vector3(xPos, yPos, zPos);
                    quad.AddComponent<Rigidbody>();
                    quad.GetComponent<Rigidbody>().useGravity = gravity;
                    quad.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(quad);
                    return entity;

                }
            }
            else //coming soon
            {
                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method creates a basic shape depending on the type passed.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>Basic functional Entity</returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            Entity entity = new Entity();
            entity.setName(entityLink);
            bool flag = (button == "3d")? true: false;
            bool gravity = false;
            int mass = 1;
            if (flag)
            {
                if (type == "plane")
                {
                    GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    plane.name = entityLink;
                    plane.transform.localScale = new Vector3(1, 1, 1);
                    plane.transform.position = new Vector3(0, 0, 0);
                    plane.AddComponent<Rigidbody>();
                    plane.GetComponent<Rigidbody>().useGravity = gravity;
                    plane.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(plane);
                    return entity;

                }
                else if (type == "cube")
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = entityLink;
                    cube.transform.localScale = new Vector3(1, 1, 1);
                    cube.transform.position = new Vector3(0, 0, 0);
                    cube.AddComponent<Rigidbody>();
                    cube.GetComponent<Rigidbody>().useGravity = gravity;
                    cube.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cube);
                    return entity;

                }
                else if (type == "sphere")
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.name = entityLink;
                    sphere.transform.localScale = new Vector3(1, 1, 1);
                    sphere.transform.position = new Vector3(0, 0, 0);
                    sphere.AddComponent<Rigidbody>();
                    sphere.GetComponent<Rigidbody>().useGravity = gravity;
                    sphere.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(sphere);
                    return entity;

                }
                else if (type == "capsule")
                {
                    GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    capsule.name = entityLink;
                    capsule.transform.localScale = new Vector3(1, 1, 1);
                    capsule.transform.position = new Vector3(0, 0, 0);
                    capsule.AddComponent<Rigidbody>();
                    capsule.GetComponent<Rigidbody>().useGravity = gravity;
                    capsule.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(capsule);
                    return entity;

                }
                else if (type == "cylinder")
                {
                    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    cylinder.name = entityLink;
                    cylinder.transform.localScale = new Vector3(1, 1, 1);
                    cylinder.transform.position = new Vector3(0, 0, 0);
                    cylinder.AddComponent<Rigidbody>();
                    cylinder.GetComponent<Rigidbody>().useGravity = gravity;
                    cylinder.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cylinder);
                    return entity;

                }
                else if (type == "quad")
                {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.name = entityLink;
                    quad.transform.localScale = new Vector3(1, 1, 1);
                    quad.transform.position = new Vector3(0, 0, 0);
                    quad.AddComponent<Rigidbody>();
                    quad.GetComponent<Rigidbody>().useGravity = gravity;
                    quad.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(quad);
                    return entity;

                }
                else throw new ShapeTypeNotFoundException();
            }
            else //coming soon. nope, it ain't
            {
                throw new NotImplementedException();
            }
        }
    }
}
