using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace EntityProvider
{
    class EntityProvider: MonoBehaviour
    {
        private EntityFactory entityFactory;
        private List<Entity> entityPool = new List<Entity>();
        //private GameObject newGameObject;
        private Entity newEntity;
        private string[] list;
        private Tokeniser tokeniser = new CommaTokeniser();
        private FileReader reader = new FileReader();
        private FactoryShop factoryShop = new FactoryShop();
        private List<string> listRead;
        protected Scene scene;
        //public string[] getEntity;
        //public GameObject loadingImage;
        //private bool generated = false;

        public void generateEntities(string fileName)
        {
            //if (generated) return;
            //loadingImage.SetActive(true);
            //SceneManager.LoadScene(1);
            //scene = SceneManager.GetSceneAt(1);
            scene = SceneManager.GetActiveScene();
            //SceneManager.UnloadScene(0);
            //SceneManager.LoadScene(0);
            if (scene.name == "main")
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else if (scene.name == "scene")
            {
                string sceneName = "";
                listRead = reader.getLines(fileName);

                foreach (string line in listRead)
                {
                    list = tokeniser.tokenise(line);
                    //look for entity, else create a new one
                    Console.WriteLine("Handling " + list[0]);
                    if (list[0] == "SceneName")
                    {
                        sceneName = list[1]; // can be used later for saving etc
                                             //scene = SceneManager.CreateScene(list[1]);
                    }

                    else if (list[0] == "Animation")
                    {
                        //optional: handle scripting by list[2]
                        //link to main entity
                    }

                    else if (list[0] == "BackgroundColour")
                    {
                        //string[] splitColours = list[1].Split('-');
                        if (list[1] == "skybox")
                        {
                            Camera camera = GetComponent<Camera>();
                            camera.clearFlags = CameraClearFlags.Skybox;
                        }
                        else{ 
                            Colour colour = new Colour(list[1], list[2]);

                            Color background = colour.getColour();
                            Camera camera = GetComponent<Camera>();

                            camera.clearFlags = CameraClearFlags.SolidColor;
                            camera.backgroundColor = background;
                        }
                    }

                    else if (list[0] == "Colour")
                    {

                        //do some major magic to link to the entity in question, if it exists
                        Colour colour = new Colour(list[2], list[3]);

                        //find the entity with the matching link in the pool
                        bool foundEntity = false;
                        for (int i = 0; i < entityPool.Count; ++i)
                        {
                            if (entityPool[i].getName() == list[1])
                            {
                                foundEntity = true;
                                entityPool[i].addColour(colour);
                                break;
                            }
                        }

                        if (!foundEntity)
                        {
                            //something went wrong
                        }
                    }

                    else if (list[0] == "Collection")
                    {
                        //look for collection factory in factory shop
                        entityFactory = factoryShop.getFactory(list[0]);
                        Collection collection = (Collection)entityFactory.build(list);
                        //get the game object (maybe from the pool, check EntityLink)
                        for (int i = 0; i < entityPool.Count; ++i)
                        {
                            if (entityPool[i].getName() == list[1]) //if EntityLinks match
                            {
                                collection.setEntity(entityPool[i]);
                                //entityPool.RemoveAt(i);             //delete it from being duplicated
                                break;
                            }
                        }
                        collection.createCollection();
                        //store it in the entity pool
                        entityPool.Add(collection);

                        //allow collection to be created remotely
                    }

                    else if (list[0] == "Texture")
                    {
                        bool foundEntity = false;
                        bool bumpMap = bool.Parse(list[2]);
                        for (int i = 0; i < entityPool.Count; ++i)
                        {
                            if (entityPool[i].getName() == list[1])
                            {
                                foundEntity = true;
                                entityPool[i].addTexture(list[3], bumpMap);
                                break; //yes? no? 
                            }
                        }

                        if (!foundEntity)
                        {
                            //something went wrong
                        }
                    }

                    else if (list[0] == "Attributes")
                    {
                        List<string> attributes = reader.getLines(list[2]);
                        bool foundEntity = false;

                        for (int i = 0; i < entityPool.Count; ++i)
                        {
                            if (entityPool[i].getName() == list[1]) // collection/entity would already be created
                            {
                                foundEntity = true;
                                entityPool[i].handleAttributes(attributes.ToArray());
                                break;
                            }
                        }

                        if (!foundEntity)
                        {
                            //something went wrong
                        }
                    }

                    else if (list[0] == "Variables")
                    {
                        //todo
                    }

                    else
                    {
                        entityFactory = factoryShop.getFactory(list[0]);
                        newEntity = entityFactory.build(list);
                        newEntity.setParent(getEntityParent(list[2]));
                        entityPool.Add(newEntity);
                    }
                    //Link entities: loop through the listRead

                    //TODO: add texture to shapes and colour

                    //check if other entities need to be created
                }
                renderScene(sceneName);
            }
        }

        public List<Entity> getEntityPool()
        {
            return this.entityPool;
        }

        public Entity getEntityParent(String name)
        {
            if (name == "null")
            {
                return null;
            }
            else if (entityPool.Exists(x => x.getName() == name))
            {
                return entityPool.Find(x => x.getName() == name);
            }
            else
            {
                throw new System.ArgumentException("Parent does not exist");
            }
        }

        protected void renderScene(string sceneName)
        {
            //loop through pool and place entities
            //render scene

            //scene = SceneManager.GetSceneByPath("Scenes\\scene.unity");

            //SceneManager.UnloadScene(scene);
            //SceneManager.LoadScene(1);

            for (int i = 0; i < entityPool.Count; ++i)
            {
                if(entityPool[i].getGameObject() != null)
                    SceneManager.MoveGameObjectToScene(entityPool[i].getGameObject(), scene);
                //Instantiate(entityPool[i].getGameObject());
            }

            //SceneManager.SetActiveScene(scene);
            //SceneManager.LoadScene(scene.name);
            //SceneManager.LoadScene(1);
           // generated = true;
        }

        public void Start()
        {
            generateEntities("Assets\\CSV\\SceneDescriptor.csv");
        }

    }
}