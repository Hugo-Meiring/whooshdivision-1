using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Leap.Unity.Interaction;

namespace EntityProvider
{
    /// <summary>
    /// This class is used to convert a CSV file into a scene. It coordinates
    /// with other helper classes to render the scene as specified to create
    /// the necessary entities.
    /// </summary>
    public class EntityProvider: MonoBehaviour
    {
        private EntityFactory entityFactory;
        private EntityPool entityPool = new ConcreteEntityPool();
        private Entity newEntity;
        private string[] list;
        private Tokeniser tokeniser = new CommaTokeniser();
        private FileReader reader = new FileReader();
        private FactoryShop factoryShop = new FactoryShop();
        private List<string> listRead;
        protected Scene scene;
        public static int sceneNumber;
        public static string csvPath;

        /// <summary>
        /// This method opens the input file and begins reading the content. This
        /// content is then created into Entities using various factories. Once 
        /// creation is complete, the scene is populated with the GameObjects.
        /// </summary>
        /// <param name="fileName">Scene Descriptor file</param>
        public void generateEntities(string fileName)
        {
            GameObject parent = new GameObject();
            GameObject[] root = SceneManager.GetActiveScene().GetRootGameObjects();

            for (int i = 0; i < root.Length; ++i)
            {
                if (root[i].name == "InteractionManager")
                    parent = root[i];
            }

            scene = SceneManager.GetActiveScene();
            string sceneName = "";
            listRead = reader.getLines(fileName);

            foreach (string line in listRead)
            {
                list = tokeniser.tokenise(line);

                if (list[0] == "SceneName")
                {
                    sceneName = list[1]; // can be used later for saving etc
                                            //scene = SceneManager.CreateScene(list[1]);
                }

                else if (list[0] == "BackgroundColour")
                {
                    GameObject[] rootObjects = scene.GetRootGameObjects();
                    Component[] userChildren;
                    Component[] vrChildren;
                    GameObject viewer = new GameObject();
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
                            for(int j = 0; j < userChildren.Length; ++j)
                            {
                                if(userChildren[j].name == "VRLeapController")
                                {
                                    vrChildren = userChildren[j].GetComponentsInChildren<MonoBehaviour>();
                                    for(int k = 0; k < vrChildren.Length; ++k)
                                    {
                                        if(vrChildren[k].name == "CenterEyeAnchor")
                                        {
                                            vrCamera = vrChildren[k];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (list[1].ToLower() == "skybox")
                    {
                        Camera camera = viewer.GetComponentInChildren<Camera>();
                        camera.clearFlags = CameraClearFlags.Skybox;

                        camera = vrCamera.GetComponent<Camera>();
                        camera.clearFlags = CameraClearFlags.Skybox;
                    }
                    else
                    { 
                        Colour colour = new Colour(list[1], list[2]);

                        Color background = colour.getColour();
                        Camera camera = viewer.GetComponentInChildren<Camera>();

                        camera.clearFlags = CameraClearFlags.SolidColor;
                        camera.backgroundColor = background;

                        camera = vrCamera.GetComponent<Camera>();
                        camera.clearFlags = CameraClearFlags.SolidColor;
                        camera.backgroundColor = background;
                    }
                }

                else if (list[0] == "Colour")
                {
                    entityPool.fetch(list[1]).addColour(new Colour(list[2], list[3]));                        
                }

                else if (list[0] == "Collection")
                {
                    entityFactory = factoryShop.getFactory(list[0]);
                    Collection collection = (Collection)entityFactory.build(list);
                    
                    Entity prototype = entityPool.fetch(list[1]);
                    entityPool.remove(prototype);
                    collection.setEntity(prototype);
                    Destroy(prototype.getGameObject());
                    prototype = null;
                    collection.createCollection();
                    entityPool.store(collection);
                }

                else if (list[0] == "CustomCollection")
                {
                    Entity prototype = entityPool.fetch(list[1]);

                    CustomCollectionFactory customCollectionFactory = (CustomCollectionFactory)factoryShop.getFactory(list[0]);
                    customCollectionFactory.setOriginal(prototype, tokeniser, reader);
                    entityPool.remove(prototype);
                    CustomCollection collection = (CustomCollection)customCollectionFactory.build(list);
                    entityPool.store(collection);
                    Destroy(prototype.getGameObject());
                    prototype = null;
                }

                else if (list[0] == "Texture")
                {
                    entityPool.fetch(list[1]).addTexture(list[2]);
                }

                else if (list[0] == "Attributes")
                {
                    List<string> attributes = reader.getLines(list[2]);
                    entityPool.fetch(list[1]).handleAttributes(attributes.ToArray());
                }

                else if (list[0] == "Variables")
                {
                    //todo
                }

                else
                {
                    entityFactory = factoryShop.getFactory(list[0]);
                    newEntity = entityFactory.build(list);
                    newEntity.getGameObject().transform.parent = parent.transform;
                    entityPool.store(newEntity);
                }
            }
            renderScene();
            
        }

        /// <summary>
        /// Method used to obtain the EntityPool
        /// </summary>
        /// <returns>The EntityPool instance.</returns>
        public EntityPool getEntityPool()
        {
            return this.entityPool;
        }

        /// <summary>
        /// Returns the parent of the given Entity.
        /// </summary>
        /// <param name="name">The name of the parent Entity.</param>
        /// <returns>Parent's Entity if found, null if the Entity does
        /// not have a parent, and throws an Exception is the specified
        /// parent doesn't exist.</returns>
        public Entity getEntityParent(String name)
        {
            if (name == "null")
            {
                return null;
            }
            else if (entityPool.fetch(name) != null)
            {
                return entityPool.fetch(name);
            }
            else
            {
                throw new System.ArgumentException("Parent does not exist");
            }
        }

        /// <summary>
        /// Method is used to traverse the EntityPool and place the GameObjects within
        /// the Entities into the scene.
        /// </summary>
        /// <param name="sceneName">Name of the scene to place the GameObjects.</param>
        public void renderScene()
        {
            GameObject[] rootObjects = scene.GetRootGameObjects();
            GameObject canvas = new GameObject();
            GameObject parent = new GameObject();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "Canvas")
                {
                    canvas = rootObjects[i];
                }
                if (rootObjects[i].name == "InteractionManager")
                {
                    parent = rootObjects[i];
                }
            }
            for (int i = 0; i < entityPool.size(); ++i)
            {
                //if(entityPool.get(i).getGameObject() != null)
                    //SceneManager.MoveGameObjectToScene(entityPool.get(i).getGameObject(), scene);
                
            }
            SceneManager.MoveGameObjectToScene(parent, scene);

            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name != "EventSystem" && rootObjects[i].name != "Canvas" && rootObjects[i].name != "_WorldPlane" && 
                    rootObjects[i].name != "Directional light" && rootObjects[i].name != "World" && rootObjects[i].name != "InteractionManager" && 
                    rootObjects[i].name != "UserController" && rootObjects[i].name != "UI" && rootObjects[i].name != "LeapEventSystem" && 
                    rootObjects[i].name != "RigidBodyFPSController")
                {
                    if (rootObjects[i].GetComponent<Rigidbody>() == null) rootObjects[i].AddComponent<Rigidbody>();
                    rootObjects[i].GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    rootObjects[i].AddComponent<InteractionBehaviour>();
                    rootObjects[i].transform.SetParent(parent.transform);
                }
            }

            Camera camera = canvas.GetComponent<Camera>();
            camera.transform.gameObject.SetActive(false);
        }

        /// <summary>
        /// Unity method for scripts. This method is called when a scene or GameObject that contains this
        /// script as a component is first loaded. It is used to begin generating Entities.
        /// </summary>
        public void Start()
        {
            string filePath;
            if (sceneNumber == 1)
            {
                filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "CSV\\Scene1.csv");
                generateEntities(filePath);
            }
            else if (sceneNumber == 2) {
                filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "CSV\\Scene2.csv");
                generateEntities(filePath);
            }
            else if(sceneNumber == 3)
            {
                filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "CSV\\Scene3.csv");
                generateEntities(filePath);
            }
            else if (csvPath != null && csvPath != "")
            {
                generateEntities(csvPath);
            }
        }

        /// <summary>
        /// Method to be used by the Editor to create Entities without specifying a CSV file.
        /// This only returns basic Entities to be customised by the users.
        /// </summary>
        /// <param name="button">The button clicked by the user.</param>
        /// <param name="entityLink">The name of the Entity being created or linked.</param>
        /// <param name="type">The type of Factory required to create the Entity.</param>
        /// <returns>Entity containing GameObject will default properties.</returns>
        public Entity CreateGameObject(string button, string entityLink, string type)
        {
            if (button == null) throw new ArgumentNullException("button", "Supply the name of the button pressed.");
            if (entityLink == null) throw new ArgumentNullException("entityLink", "A name of an entity must be provided.");
            if (type == null) throw new ArgumentNullException("type", "Type of entity must be supplied.");

            if (button == "collection")
            {
                    return factoryShop.getFactory("Collection").buildBasic(button, entityLink, type);
            }
            else if (button == "shape")
            {
                if (type == "cylinder" || type == "plane" || type == "cube" || type == "sphere" || type == "quad" || type == "capsule")
                {
                    return factoryShop.getFactory("Shape").buildBasic(button, entityLink, type);
                }
                else throw new ShapeTypeNotFoundException();
            }
            else if(button == "point" || button == "spot" || button == "directional" || button == "area")
            {
                return factoryShop.getFactory("Light").buildBasic(button, entityLink, type);
            }

            throw new ArgumentException("Button not recognised.");
        }

        /// <summary>
        /// Method used to set the background colour of the scene. If the parameter is a
        /// "skybox", then a Unity skybox will be added to the scene, else a solid colour 
        /// will be set.
        /// </summary>
        /// <param name="colour">Name of the colour to be set.</param>
        public void SetBackground(string colour)
        {
            GameObject[] rootObjects = scene.GetRootGameObjects();
            Component[] userChildren;
            Component[] vrChildren;
            GameObject viewer = new GameObject();
            GameObject canvas = new GameObject();
            Component vrCamera = new Component();
            for (int i = 0; i < rootObjects.Length; ++i)
            {
                if (rootObjects[i].name == "RigidBodyFPSController")
                {
                    viewer = rootObjects[i];
                }
                if(rootObjects[i].name == "Canvas")
                {
                    canvas = rootObjects[i];
                }
                if (rootObjects[i].name == "UserController")
                {
                    userChildren = rootObjects[i].GetComponentsInChildren<Component>();
                    for (int j = 0; j < userChildren.Length; ++j)
                    {
                        if (userChildren[j].name == "VRLeapController")
                        {
                            vrChildren = userChildren[j].GetComponentsInChildren<Component>();
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
            if (colour == "skybox")
            {
                Camera camera = canvas.GetComponent<Camera>();
                camera.clearFlags = CameraClearFlags.Skybox;

                camera = viewer.GetComponentInChildren<Camera>();
                camera.clearFlags = CameraClearFlags.Skybox;

                camera = vrCamera.GetComponent<Camera>();
                camera.clearFlags = CameraClearFlags.Skybox;
            }
            else
            { 
                Colour colr = new Colour("null", colour);

                Color background = colr.getColour();
                Camera camera = canvas.GetComponent<Camera>();

                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = background;

                camera = viewer.GetComponentInChildren<Camera>();

                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = background;

                camera = vrCamera.GetComponent<Camera>();

                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = background;
            }
            
        }

        /// <summary>
        /// Method used to store Entities in the EntityPool.
        /// </summary>
        /// <param name="entity">Reference to the Entity being stored.</param>
        public void StoreEntity(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity", "Cannot store a null object in the entity pool");
            entityPool.store(entity);
        }

        /// <summary>
        /// Sets the scene to be used in EntityProvider. This is alternative
        /// to setting the scene index number.
        /// </summary>
        /// <param name="seen">Scene to be set.</param>
        /// <returns>The scene being used after it was set.</returns>
        public Scene setScene(Scene seen)
        {
            scene = seen;
            return scene;
        }
    }
}