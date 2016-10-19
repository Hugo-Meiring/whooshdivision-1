using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;



namespace EntityProvider
{
   
    public class NewBehaviourScript : MonoBehaviour
    {
        public string modelPath = "";
        private EntityProperties properties = new EntityProperties();
        private EditorEntity editorEntity = new EditorEntity();
            private EntityProvider entityProvider;
            private List<Entity> objectShapes = new List<Entity>();
            private List<Entity> objectCollections = new List<Entity>();
            private List<Entity> objectModels = new List<Entity>();
            private List<Entity> objectLights = new List<Entity>();
            private Rect dropDownRect = new Rect(1080, 20, 128, 100);
        public Renderer render;
        private Texture cube;
            private Texture cycle;
            private Texture rectangle;
            private Texture sphere;
            private Texture quad;
        private Texture plane;
            private Texture cyclinder;
            private Texture capsule;

        private Texture stack;
        private Texture row;
        private Texture random;
        private Texture threeD;

        private Texture spot;
        private Texture point;
        private Texture direction;
        private Texture area;

        private bool showShape = false;
        private bool showCollection = false;
        private bool showLight = false;
        private bool showModel = false;
        private bool background = true;

        private string backgroundColor = "skybox";
     
        private int selectedShape = -1;
        private int selectedCollection = -1;
        private int selectedLight = -1;
        private bool showGUI = true;

   
        private Texture[] list;
            private Texture[] CollectionList;
            private Texture[] LightList;
            private Texture[] ModelList;
       
            public Rect windowRect = new Rect(1075, 0, 200, 1000);
            public Rect windowRect1 = new Rect(0, 0, 200, 1000);
        GUIStyle style = new GUIStyle();
        private bool sho = false;
        private bool sh = false;
        private bool s = false;
        private bool showModelP = false;
        private string texture = "None";
        // GUIStyle style1 = new GUIStyle();
        private int t = 0;
        private GameObject obj;
        private string matColor = "white";
        private Entity entity;
        private string name1 = "hello";

        private string posX = "";
        private string posY = "";
        private string posZ = "";
        private Vector3 screenPoint;
        private Vector3 offset;
        private Vector3 scanPos;
        private string rotateX = "";
        private string rotateY = "";
        private string rotateZ = "";

        private string scaleX = "";
        private string scaleY = "";
        private string scaleZ = "";
  
        void Start()
            {
       
                cube = new Texture();
                cube = Resources.Load<Texture>("cube");
                cycle = new Texture();
                cycle = Resources.Load<Texture>("cycle");
                capsule = new Texture();
                capsule = Resources.Load<Texture>("capsule");
                rectangle = new Texture();
                rectangle = Resources.Load<Texture>("rectangle");
                quad = new Texture();
                quad = Resources.Load<Texture>("quad");
                sphere = new Texture();
                sphere = Resources.Load<Texture>("sphere");
                cyclinder = new Texture();
                cyclinder = Resources.Load<Texture>("cylinder");
                plane = new Texture();
                plane = Resources.Load<Texture>("plane");
            
            stack = new Texture();
            stack = Resources.Load<Texture>("stack");
            row = new Texture();
            row = Resources.Load<Texture>("row");
            random = new Texture();
            random = Resources.Load<Texture>("random");
            threeD = new Texture();
            threeD = Resources.Load<Texture>("threeD");


            point = new Texture();
            point = Resources.Load<Texture>("point");
            spot = new Texture();
            spot = Resources.Load<Texture>("spot");
            direction = new Texture();
            direction = Resources.Load<Texture>("direction");
            area = new Texture();
            area = Resources.Load<Texture>("area");


            list = new Texture[4];
            list[0] = cube;
            list[1] = sphere;
            list[2] = capsule;
            list[3] = cyclinder;
            //list[4] = quad;
            //list[5] = plane;

            entityProvider = new EntityProvider();
            GameObject obj = new GameObject();

            CollectionList = new Texture[4];
            CollectionList[0] = stack;
            CollectionList[1] = row;
            CollectionList[2] = random;
            CollectionList[3] = threeD;

            LightList = new Texture[4];
            LightList[0] = point;
            LightList[1] = spot;
            LightList[2] = direction;
            LightList[3] = area;


         
            /* style.alignment = TextAnchor.MiddleCenter;
             RectOffset margin =  new RectOffset();
             margin.bottom = 10;
             margin.top = 10;
             style.margin = margin;
             style.normal.background = new Texture2D(1, 1);*/








        }

        int indexNumber;
            bool show = false;
            int i;
            int length = 0;
            int col = 0;
            int li = 0;
        int number = -1;
        void OnGUI()
            {
            if (showGUI)
            {
                windowRect = GUI.Window(0, windowRect, window, "");
                windowRect1 = GUI.Window(1, windowRect1, window1, "Scene");

                if (GUI.Button(new Rect(dropDownRect.x, dropDownRect.y, 150, 25), "Shapes",style))
                {
                    showShape = true;
                }
                if (GUI.Button(new Rect(dropDownRect.x, dropDownRect.y + 25 + length, 150, 25), "Collections",style))
                {
                    showCollection = true;
                }
                if (GUI.Button(new Rect(dropDownRect.x, dropDownRect.y + 50 + length + col, 150, 25), "Light",style))
                {
                    showLight = true;
                }
                if (GUI.Button(new Rect(dropDownRect.x, dropDownRect.y + 75 + length + col + li, 150, 25), "Model",style))
                {
                    showModel = true;
                }
                if (showShape)
                {
                    length = 35;
                    col = 0;
                    li = 0;
                    showCollection = false;
                    showLight = false;
                    showModel = false;
                    //GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 20, 100, 60),"");
                    selectedShape = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 25, 100, 25), selectedShape, list, 4,style);
                    if (selectedShape != -1)
                    {
                        objectShapes.Add(editorEntity.getShape(selectedShape));
                        showShape = false;
                        length = 0;
                    }

                    selectedShape = -1;
                    

                    //showShape = false;

                }
                if (showCollection)
                {
                    length = 0;
                    col = 35;
                    li = 0;
                    showShape = false;
                    showLight = false;
                    showModel = false;
                  //  GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 50, 100, 35), "");
                    selectedCollection = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 55, 100, 25), selectedCollection, CollectionList, 4,style);
                    if(selectedCollection != -1)
                    {
                        objectCollections.Add(editorEntity.getCollection(selectedCollection));
                        showCollection = false;
                        col = 0;
                    }
                    selectedCollection = -1;
                }
                if (showLight)
                {
                    length = 0;
                    col = 0;
                    li = 35;
                    showShape = false;
                    showCollection = false;
                    showModel = false;
                  //  GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 75, 100, 35),"");
                    selectedLight = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 80, 100, 25), selectedLight, LightList, 4,style);
                    if(selectedLight != -1)
                    {
                        objectLights.Add(editorEntity.getLight(selectedLight));
                        showLight = false;
                        li = 0;
                    }
                    selectedLight = -1;
                }
                if (showModel)
                {
                    length = 0;
                    col = 0;
                    li = 0;
                    showShape = false;
                    showCollection = false;
                    showLight = false;
                    modelPath = GUI.TextField(new Rect(dropDownRect.x,dropDownRect.y + 95, 100, 25), modelPath, 100);
                    if (GUI.Button(new Rect(dropDownRect.x + 100, dropDownRect.y + 95, 60, 25), "Render"))
                    {
                        objectModels.Add(editorEntity.getModel(modelPath));
                        showModel = false;
                    }

                }
                GUI.Box(new Rect(500, 0, 210, 25), "");
                if (GUI.Button(new Rect(500, 0, 100, 25), "Done"))
                {
                    removeWindows();
                }
                if (GUI.Button(new Rect(610, 0, 100, 25), "Save Scene"))
                {
                    removeWindows();
                    //save to assets/scene 
                }
            }

            if (sho)
            {
              
                
                GUI.Box(new Rect(1075, 175, 190, 250), "");
                GUI.Label(new Rect(1080, 185, 50, 25), "Name : ");
               name1 = GUI.TextField(new Rect(1130,185 , 100, 20), name1,50);
                GUI.Label(new Rect(1080, 210, 50, 25), "Color : ");
                matColor = GUI.TextField(new Rect(1130, 210, 100, 20), matColor,50);
                GUI.Label(new Rect(1080, 235, 50, 25), "Texture : ");
                texture = GUI.TextField(new Rect(1130, 235, 100, 20), texture,50);

                

                GUI.Label(new Rect(1080, 260, 100, 25), "Transform");

                GUI.Label(new Rect(1080, 285, 60, 25), "Position : ");
                GUI.Label(new Rect(1140, 285, 10, 20), "X");
                posX = GUI.TextField(new Rect(1150, 285, 27, 20), posX,20);
                GUI.Label(new Rect(1180, 285, 10, 20), "Y");
                posY = GUI.TextField(new Rect(1190, 285, 27, 20), posY,20);
                GUI.Label(new Rect(1220, 285, 10, 20), "Z");
                posZ = GUI.TextField(new Rect(1230, 285, 27, 20), posZ,20);

                GUI.Label(new Rect(1080, 310, 60, 25), "Rotation : ");
                GUI.Label(new Rect(1140, 310, 10, 20), "X");
                rotateX = GUI.TextField(new Rect(1150, 310, 27, 20), rotateX,20);
                GUI.Label(new Rect(1180, 310, 10, 25), "Y");
                rotateY = GUI.TextField(new Rect(1190, 310, 27, 20), rotateY,20);
                GUI.Label(new Rect(1220, 310, 10, 25), "Z");
                rotateZ = GUI.TextField(new Rect(1230, 310, 27, 20), rotateZ,20);

                GUI.Label(new Rect(1080, 335, 60, 25), "Scale     : ");
                GUI.Label(new Rect(1140, 335, 10, 20), "X");
                scaleX = GUI.TextField(new Rect(1150, 335, 27, 20), scaleX,20);
                GUI.Label(new Rect(1180, 335, 10, 20), "Y");
                scaleY = GUI.TextField(new Rect(1190, 335, 27, 20), scaleY,20);
                GUI.Label(new Rect(1220, 335, 10, 20), "Z");
                scaleZ = GUI.TextField(new Rect(1230, 335, 27, 20), scaleZ,20);
                if(GUI.Button(new Rect(1080,365,50,25),"Apply"))
                {
                    scale();
                    rotation();
                    position();
                    changeColor();
                    sho = false;

                }

                if(GUI.Button(new Rect(1160,365,50,25),"Delete"))
                {
                    delete();
                }

         



            }


        }

        private void getModel(string modelPath)
        {

        }
        public void changeName()
        {
            entity.setName(name1);
        }
        public void scale()
        {
            float x = float.Parse(scaleX);
            float y = float.Parse(scaleY);
            float z = float.Parse(scaleZ);

            obj.transform.localScale = new Vector3(x, y, z);
        }

        public void position()
        {
            float x = float.Parse(posX);
            float y = float.Parse(posY);
            float z = float.Parse(posZ);

            obj.transform.position = new Vector3(x, y, z);

        }

        public void rotation()
        {
            float x = float.Parse(rotateX);
            float y = float.Parse(rotateY);
            float z = float.Parse(rotateZ);

            obj.transform.Rotate(new Vector3(x, y, z));
        }

        public void changeColor()
        {
            Color newColor = new Color();
            ColorUtility.TryParseHtmlString(matColor, out newColor);
            obj.AddComponent<Renderer>();
            obj.GetComponent<Renderer>().material.color = newColor;
            render = obj.GetComponent<Renderer>();
                
        }

        public void delete()
        {
            sho = false;
            Destroy(obj);
        }
        private void textur()
        {
            Texture newTexture = new Texture();
            newTexture = Resources.Load<Texture>(texture);
            obj.GetComponent<Renderer>().material.SetTexture(t, newTexture);
            t++;
        }
        void removeWindows()
        {
            showGUI = false;
        }
        public void editProperties(Entity entity)
        {
            Entity temp = new Entity();
            
            temp = entity;
            obj = temp.getGameObject();

            name1 = temp.getName();

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
   
        void window(int windowID)
        {
            
        

        }

        private void saveEntity(Entity entity)
        {

        }
            public void window1(int windowID)
            {
            
               
            if(GUI.Button(new Rect(16,15,50,20),"Background",style))
            {
                background = true;
            }
            if(background)
            {
                backgroundColor = GUI.TextField(new Rect(16, 30, 100, 20), backgroundColor, 100);
                if(GUI.Button(new Rect(120,30,30,20),"Set"))
                {
                    entityProvider.SetBackground(backgroundColor);

                }
               
            }


            for (int y = 0; y < objectShapes.Count; y++)
                {
                    if(y == 0)
                        GUI.Label(new Rect(20, 40, 120, 20), new GUIContent("Shapes"));

                    if(GUI.Button(new Rect(30,  (y* 20 + 20), 120, 20), new GUIContent(objectShapes[y].getName()),style))
                    {
                    sho = true;
                    number = y;
                            
                    }
                }

                for(int p = 0; p < objectCollections.Count; p++)
                {
                    if(p == 0)
                        GUI.Label(new Rect(20, (p * 10), 120, 20), new GUIContent("Collections"));

                 if(GUI.Button(new Rect(30, (p* 10), 120, 20), new GUIContent(objectCollections[p].getName())))
                {
                    sh = true;
                    number = p;
                }
                }

                for(int u = 0; u < objectLights.Count;u++)
                {
                    if(u == 0)
                        GUI.Label(new Rect(20, (u * 10), 120, 20), new GUIContent("Lights"));

                   if(GUI.Button(new Rect(30, (u * 10), 120, 20), new GUIContent(objectLights[u].getName())))
                {
                    s = true;
                    number = u;
                }
                }
                for(int l = 0; l < objectModels.Count;l++)
                {
                    if(l == 0)
                        GUI.Label(new Rect(20, (l * 10), 120, 20), new GUIContent("Models"));

                if(GUI.Button(new Rect(30, (l * 10), 120, 20), new GUIContent(objectShapes[l].getName())))
                {
                    showModelP = true;
                    number = l;
                }
                }
            if (sho)
            {
                editProperties(objectShapes[number]);
                
            }
            if(sh)
            {
                editProperties(objectCollections[number]);
            }
            if(s)
            {
                editProperties(objectLights[number]);
            }
            if(showModelP)
            {
                editProperties(objectModels[number]);
            }
            }
       
    }
}
    

   
