using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace EntityProvider
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public string modelPath = "";
        private EntityProperties properties = new EntityProperties();
        private EditorEntity editorEntity = new EditorEntity();
            private EntityProvider entityProvider = new EntityProvider();
            private List<Entity> objectShapes = new List<Entity>();
            private List<Entity> objectCollections = new List<Entity>();
            private List<Entity> objectModels = new List<Entity>();
            private List<Entity> objectLights = new List<Entity>();
            private Rect dropDownRect = new Rect(1080, 20, 128, 100);

            private Texture cube;
            private Texture cycle;
            private Texture rectangle;
            private Texture sphere;
            private Texture square;
            private Texture triangle;
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
       // GUIStyle style1 = new GUIStyle();

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
                square = new Texture();
                square = Resources.Load<Texture>("square");
                sphere = new Texture();
                sphere = Resources.Load<Texture>("sphere");
                cyclinder = new Texture();
                cyclinder = Resources.Load<Texture>("cyclinder");
                triangle = new Texture();
                triangle = Resources.Load<Texture>("triangle");
            
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

            void OnGUI()
            {
            if (showGUI)
            {
                windowRect = GUI.Window(0, windowRect, window, "");
                windowRect1 = GUI.Window(1, windowRect1, window1, "");

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
                    GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 25, 100, 35),"");
                    selectedShape = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 30, 100, 25), selectedShape, list, 4);
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
                    GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 50, 100, 35), "");
                    selectedCollection = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 55, 100, 25), selectedCollection, CollectionList, 4);
                }
                if (showLight)
                {
                    length = 0;
                    col = 0;
                    li = 35;
                    showShape = false;
                    showCollection = false;
                    showModel = false;
                    GUI.Box(new Rect(dropDownRect.x, dropDownRect.y + 75, 100, 35),"");
                    selectedLight = GUI.SelectionGrid(new Rect(dropDownRect.x, dropDownRect.y + 80, 100, 25), selectedLight, LightList, 4);
                }
                if (showModel)
                {
                    length = 0;
                    col = 0;
                    li = 0;
                    showShape = false;
                    showCollection = false;
                    showLight = false;
                    modelPath = GUI.TextArea(new Rect(dropDownRect.x,dropDownRect.y + 100, 100, 25), modelPath, 200);

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
          
    }
        void removeWindows()
        {
            showGUI = false;
        }
        void window(int windowID)
        {
            
        

        }

        private void saveEntity(Entity entity)
            {

            }
            public void window1(int windowID)
            {

                GUI.Label(new Rect(10,0,120,30),"Scene");
                for(int y = 0; y < objectShapes.Count; y++)
                {
                    if(y == 0)
                        GUI.Label(new Rect(20, (10), 120, 30), new GUIContent("Shapes"));

                    if(GUI.Button(new Rect(30, (y* 20 + 20), 120, 30), new GUIContent(objectShapes[y].getName())))
                    {
                             properties.editProperties(objectShapes[y]);
                    }
                }

                for(int p = 0; p < objectCollections.Count; p++)
                {
                    if(p == 0)
                        GUI.Label(new Rect(20, (p * 10), 120, 30), new GUIContent("Collections"));

                    GUI.Button(new Rect(30, (p* 10), 120, 30), new GUIContent(objectCollections[p].getName()));
                }

                for(int u = 0; u < objectLights.Count;u++)
                {
                    if(u == 0)
                        GUI.Label(new Rect(20, (u * 10), 120, 30), new GUIContent("Lights"));

                    GUI.Button(new Rect(30, (u * 10), 120, 30), new GUIContent(objectLights[u].getName()));
                }
                for(int l = 0; l < objectModels.Count;l++)
                {
                    if(l == 0)
                        GUI.Label(new Rect(20, (l * 10), 120, 30), new GUIContent("Models"));

                    GUI.Button(new Rect(30, (l * 10), 120, 30), new GUIContent(objectShapes[l].getName()));
                }
            }
    }
}
    

   