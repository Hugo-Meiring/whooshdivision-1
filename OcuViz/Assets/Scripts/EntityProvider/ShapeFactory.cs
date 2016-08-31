using UnityEngine;
using System.Collections;

namespace EntityProvider
{
    class ShapeFactory : EntityFactory
    {
        public override Entity build(string[] list) //Shape, EntityLink, parent, type, 3D_FLAG, USE_GRAVITY, mass, xlen, ylen[, zlen], xpos, ypos, zpos
        {
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
                    plane.transform.localScale = new Vector3(x, y, z);
                    plane.transform.position = new Vector3(xPos, yPos, zPos);
                    plane.AddComponent<Rigidbody>();
                    if (gravity) plane.GetComponent<Rigidbody>().useGravity = true;
                    else plane.GetComponent<Rigidbody>().useGravity = false;
                    plane.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(plane);
                    return entity;

                }
                else if (list[3] == "cube")
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(x, y, z);
                    cube.transform.position = new Vector3(xPos, yPos, zPos);
                    cube.AddComponent<Rigidbody>();
                    if (gravity) cube.GetComponent<Rigidbody>().useGravity = true;
                    else cube.GetComponent<Rigidbody>().useGravity = false;
                    cube.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cube);
                    return entity;

                }
                else if (list[3] == "sphere")
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(x, y, z);
                    sphere.transform.position = new Vector3(xPos, yPos, zPos);
                    sphere.AddComponent<Rigidbody>();
                    if (gravity) sphere.GetComponent<Rigidbody>().useGravity = true;
                    else sphere.GetComponent<Rigidbody>().useGravity = false;
                    sphere.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(sphere);
                    return entity;

                }
                else if (list[3] == "capsule")
                {
                    GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    capsule.transform.localScale = new Vector3(x, y, z);
                    capsule.transform.position = new Vector3(xPos, yPos, zPos);
                    capsule.AddComponent<Rigidbody>();
                    if (gravity) capsule.GetComponent<Rigidbody>().useGravity = true;
                    else capsule.GetComponent<Rigidbody>().useGravity = false;
                    capsule.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(capsule);
                    return entity;

                }
                else if (list[3] == "cylinder")
                {
                    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    cylinder.transform.localScale = new Vector3(x, y, z);
                    cylinder.transform.position = new Vector3(xPos, yPos, zPos);
                    cylinder.AddComponent<Rigidbody>();
                    if (gravity) cylinder.GetComponent<Rigidbody>().useGravity = true;
                    else cylinder.GetComponent<Rigidbody>().useGravity = false;
                    cylinder.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(cylinder);
                    return entity;

                }
                else if (list[3] == "quad")
                {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.transform.localScale = new Vector3(x, y, z);
                    quad.transform.position = new Vector3(xPos, yPos, zPos);
                    quad.AddComponent<Rigidbody>();
                    if (gravity) quad.GetComponent<Rigidbody>().useGravity = true;
                    else quad.GetComponent<Rigidbody>().useGravity = false;
                    quad.GetComponent<Rigidbody>().mass = mass;
                    entity.setGameObject(quad);
                    return entity;

                }
            }
            else //coming soon
            {
                int x = int.Parse(list[7]);
                int y = int.Parse(list[8]);

                float xPos = float.Parse(list[9]);
                float yPos = float.Parse(list[10]);
                float zPos = float.Parse(list[11]);

                if (list[3] == "triangle")
                {
                }

                else if (list[3] == "square" || list[3] == "rectangle")
                {
                }

                else if (list[3] == "cycle")
                {
                }
            }
            return new Entity(); //must be fixed!
        }
    }
}
