using UnityEngine;
using System.Collections;

namespace EntityProvider
{
    class ShapeFactory : EntityFactory
    {
        public override GameObject build(string[] list)
        {
            typeName = list[0];
            bool flag = bool.Parse(list[4]);
            if (flag)
            {
                int x = int.Parse(list[6]);
                int y = int.Parse(list[7]);
                int z = int.Parse(list[8]);
                if (list[3] == "plane")
                {
                    GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    plane.transform.position = new Vector3(x, y, z);
                    return plane;

                }
                else if (list[3] == "cube")
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x, y, z);
                    return cube;

                }
                else if (list[3] == "sphere")
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = new Vector3(x, y, z);
                    return sphere;

                }
                else if (list[3] == "capsule")
                {
                    GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    capsule.transform.position = new Vector3(x, y, z);
                    return capsule;

                }
                else if (list[3] == "cylinder")
                {
                    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    cylinder.transform.position = new Vector3(x, y, z);
                    return cylinder;

                }
                else if (list[3] == "quad")
                {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.transform.position = new Vector3(x, y, z);
                    return quad;

                }
            }
            else
            {
                int x = int.Parse(list[6]);
                int y = int.Parse(list[7]);

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
            return new GameObject(); //must be fixed!
        }
    }
}
