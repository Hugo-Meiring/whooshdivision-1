using UnityEngine;
using UnityEditor;
using System.Collections;


namespace EntityProvider {
  
    public class EntityProperties  {
        private bool show = false;
        private GameObject obj = new GameObject();
        private Color matColor = Color.white;
        private Entity entity;
        private string name = "";

        private string posX = "";
        private string posY = "";
        private string posZ = "";

        private string rotateX = "";
        private string rotateY = "";
        private string rotateZ = "";

        private string scaleX = "";
        private string scaleY = "";
        private string scaleZ = "";


        public void OnGUI()
        {
            if(show)
            {
                name = entity.getName();
                GUI.Box(new Rect(1080, 200, 200, 250), "");
                GUI.Label(new Rect(1080, 210, 50, 25), "Name : ");
                name = GUI.TextField(new Rect(1130, 210, 100, 25), name);
                matColor = EditorGUILayout.ColorField("Color", matColor);
                GUI.Label(new Rect(1080, 260, 100, 25), "Transform");

                GUI.Label(new Rect(1080, 285, 30, 25), "Position");
                GUI.Label(new Rect(1110, 285, 10, 25), "X");
                posX = GUI.TextField(new Rect(1120, 285, 20, 25), posX);
                GUI.Label(new Rect(1140, 285, 10, 25), "Y");
                posY = GUI.TextField(new Rect(1150, 285, 20, 25), posY);
                GUI.Label(new Rect(1170, 285, 10, 25), "Z");
                posZ = GUI.TextField(new Rect(1180, 285, 20, 25), posZ);

                GUI.Label(new Rect(1080, 310, 30, 25), "Rotation");
                GUI.Label(new Rect(1110, 310, 10, 25), "X");
                rotateX = GUI.TextField(new Rect(1120, 310, 20, 25), rotateX);
                GUI.Label(new Rect(1140, 285, 10, 25), "Y");
                rotateY = GUI.TextField(new Rect(1150, 310, 20, 25), rotateY);
                GUI.Label(new Rect(1170, 285, 10, 25), "Z");
                rotateZ = GUI.TextField(new Rect(1180, 310, 20, 25), rotateZ);

                GUI.Label(new Rect(1080, 335, 30, 25), "Scale");
                GUI.Label(new Rect(1110, 335, 10, 25), "X");
                scaleX = GUI.TextField(new Rect(1120, 335, 20, 25), scaleX);
                GUI.Label(new Rect(1140, 335, 10, 25), "Y");
                scaleY = GUI.TextField(new Rect(1150, 310, 20, 25), scaleY);
                GUI.Label(new Rect(1170, 355, 10, 25), "Z");
                scaleZ = GUI.TextField(new Rect(1180, 335, 20, 25), scaleZ);




            }

        }

        public void editProperties(Entity entity)
        {
            this.entity = entity;
            obj = entity.getGameObject();

            posX = obj.transform.position.x.ToString();
            posY = obj.transform.position.y.ToString();
            posZ = obj.transform.position.z.ToString();

            rotateX = "0";
            rotateY = "0";
            rotateZ = "0";

            scaleX = "1";
            scaleY = "1";
            scaleZ = "1";
            show = true;


        }
        public void ChangeColors()
        {
            if (Selection.activeGameObject)
                foreach (GameObject t in Selection.gameObjects)
                {
                    Renderer rend = t.GetComponent<Renderer>();

                    if (rend != null)
                        rend.sharedMaterial.color = matColor;
                }
        }
    }
}