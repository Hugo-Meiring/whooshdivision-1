using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace EntityProvider
{
    /// <summary>
    /// This class is used to convert a CSV file into a scene. It coordinates
    /// with other helper classes to render the scene as specified to create
    /// the necessary entities.
    /// </summary>
    class EntityProvider: MonoBehaviour
    {
        private EntityFactory entityFactory;
        private EntityPool entityPool = new ConcreteEntityPool();
        //private GameObject newGameObject;
        private Entity newEntity;
        private string[] list;
        private Tokeniser tokeniser = new CommaTokeniser();
        private FileReader reader = new FileReader();
        private FactoryShop factoryShop = new FactoryShop();
        private List<string> listRead;
        protected Scene scene;
        public static int sceneNumber = 1;
        //public string[] getEntity;
        //public GameObject loadingImage;
        //private bool generated = false;

        /// <summary>
        /// This method opens the input file and begins reading the content. This
        /// content is then created into Entities using various factories. Once 
        /// creation is complete, the scene is populated with the GameObjects.
        /// </summary>
        /// <param name="fileName"></param>
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
                        if (list[1].ToLower() == "skybox")
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
                        //bool foundEntity = false;
                        //for (int i = 0; i < entityPool.Count; ++i)
                        //{
                        //    if (entityPool[i].getName() == list[1])
                        //    {
                        //        foundEntity = true;
                        //        entityPool[i].addColour(colour);
                        //        break;
                        //    }
                        //}

                        //rewrite
                        entityPool.fetch(list[1]).addColour(colour);                        
                    }

                    else if (list[0] == "Collection")
                    {
                        //look for collection factory in factory shop
                        entityFactory = factoryShop.getFactory(list[0]);
                        Collection collection = (Collection)entityFactory.build(list);

                        //get the game object (maybe from the pool, check EntityLink)
                        //for (int i = 0; i < entityPool.Count; ++i)
                        //{
                        //    if (entityPool[i].getName() == list[1]) //if EntityLinks match
                        //    {
                        //        collection.setEntity(entityPool[i]);
                        //        //entityPool.RemoveAt(i);             //delete it from being duplicated
                        //        break;
                        //    }
                        //}

                        //rewrite
                        Entity prototype = entityPool.fetch(list[1]);
                        entityPool.remove(prototype);
                        collection.setEntity(prototype);
                        Destroy(prototype.getGameObject());
                        collection.createCollection();
                        entityPool.store(collection);

                        //allow collection to be created remotely
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
                    }

                    else if (list[0] == "Texture")
                    {
                        bool foundEntity = false;
                        bool bumpMap = bool.Parse(list[2]);

                        //old
                        //for (int i = 0; i < entityPool.Count; ++i)
                        //{
                        //    if (entityPool[i].getName() == list[1])
                        //    {
                        //        foundEntity = true;
                        //        entityPool[i].addTexture(list[3], bumpMap);
                        //        break; //yes? no? 
                        //    }
                        //}

                        //new
                        entityPool.fetch(list[1]).addTexture(list[3], bumpMap);

                        //if (!foundEntity)
                        //{
                        //    //something went wrong
                        //    throw new System.ArgumentException(list[1] + " was not found.");
                        //}
                    }

                    else if (list[0] == "Attributes")
                    {
                        List<string> attributes = reader.getLines(list[2]);
                        bool foundEntity = false;

                        //old
                        //for (int i = 0; i < entityPool.Count; ++i)
                        //{
                        //    if (entityPool[i].getName() == list[1]) // collection/entity would already be created
                        //    {
                        //        foundEntity = true;
                        //        entityPool[i].handleAttributes(attributes.ToArray());
                        //        break;
                        //    }
                        //}

                        //new
                        entityPool.fetch(list[1]).handleAttributes(attributes.ToArray());

                        //if (!foundEntity)
                        //{
                        //    //something went wrong
                        //}
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
                        entityPool.store(newEntity);
                    }
                    //Link entities: loop through the listRead

                    //TODO: add texture to shapes and colour

                    //check if other entities need to be created
                }
                renderScene(sceneName);
            }
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
        protected void renderScene(string sceneName)
        {
            //loop through pool and place entities
            //render scene

            //scene = SceneManager.GetSceneByPath("Scenes\\scene.unity");

            //SceneManager.UnloadScene(scene);
            //SceneManager.LoadScene(1);

            for (int i = 0; i < entityPool.size(); ++i)
            {
                if(entityPool.get(i).getGameObject() != null)
                SceneManager.MoveGameObjectToScene(entityPool.get(i).getGameObject(), scene);
                //Instantiate(entityPool[i].getGameObject());
            }

            Camera camera = GetComponent<Camera>();
            camera.transform.gameObject.SetActive(false);

            //SceneManager.SetActiveScene(scene);
            //SceneManager.LoadScene(scene.name);
            //SceneManager.LoadScene(1);
           // generated = true;
        }

        /// <summary>
        /// Unity method for scripts. This method is called when a scene or GameObject that contains this
        /// script as a component is first loaded. It is used to begin generating Entities.
        /// </summary>
        public void Start()
        {
            if (sceneNumber == 1) generateEntities("Assets\\CSV\\Scene1.csv");
            else if (sceneNumber == 2) generateEntities("Assets\\CSV\\Scene2.csv");
        }

        /// <summary>
        /// Method to be used by the Editor to create Entities without specifying a CSV file.
        /// This only returns basic Entities to be customised by the users.
        /// </summary>
        /// <param name="button">The button clicked by the user.</param>
        /// <param name="entityLink">The name of the Entity being created or linked.</param>
        /// <param name="type">The type of Factory required to create the Entity.</param>
        /// <returns></returns>
        public Entity CreateGameObject(string button, string entityLink, string type)
        {
            if (button == "shapes" || button == "models")
            {
                    return factoryShop.getFactory("Collection").buildBasic(button, entityLink, type);
            }
            else if (button == "2d" || button == "3d")
            {
                if (type == "model")
                {
                    return factoryShop.getFactory("Model").buildBasic(button, entityLink, type);
                }
                else
                    return factoryShop.getFactory("Shape").buildBasic(button, entityLink, type);
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
            if(colour == "skybox")
            {
                Camera camera = GetComponent<Camera>();
                camera.clearFlags = CameraClearFlags.Skybox;
            }
            else
            { 
                Colour colr = new Colour(list[1], list[2]);

                Color background = colr.getColour();
                Camera camera = GetComponent<Camera>();

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
            entityPool.store(entity);
        }

    }
}