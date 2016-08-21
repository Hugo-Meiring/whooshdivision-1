using System;
using UnityEngine;
using System.Collections;
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
        //public string[] getEntity;

        public void generateEntities(string fileName)
        {
            listRead = reader.getLines(fileName);

            foreach (string line in listRead)
            {
                list = tokeniser.tokenise(line);
                //look for entity, else create a new one
                if (list[0] == "Animation")
                {
                    //optional: handle scripting by list[2]
                    //link to main entity
                }

                else if (list[0] == "BackgroundColour")
                {
                    //string[] splitColours = list[1].Split('-');
                    Colour colour = new Colour(list[1], list[2]);

                    Color background = colour.getColour();
                    Camera camera = GetComponent<Camera>();

                    camera.clearFlags = CameraClearFlags.SolidColor;
                    camera.backgroundColor = background;
                }

                else if (list[0] == "Colour")
                {

                    //do some major magic to link to the entity in question, if it exists
                    Colour colour = new Colour(list[2], list[3]);

                    //find the entity with the matching link in the pool
                    bool foundEntity = false;
                    for(int i = 0; i < entityPool.Count; ++i)
                    {
                        if(entityPool[i].getName() == list[1])
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

                else if(list[0] == "Collection")
                {
                    //look for collection factory in factory shop
                    entityFactory = factoryShop.getFactory(list[0]);
                    Collection collection = (Collection) entityFactory.build(list);
                    //get the game object (maybe from the pool, check EntityLink)
                    for(int i = 0; i < entityPool.Count; ++i)
                    {
                        if(entityPool[i].getName() == list[1])
                        {
                            collection.setEntity(entityPool[i]);
                            break;
                        }
                    }
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
                            entityPool[i].handleAttributes(attributes);
                            break;
                        }
                    }

                    if (!foundEntity)
                    {
                        //something went wrong
                    }
                }

                else if(list[0] == "Variables")
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
            renderScene();

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

        protected void renderScene()
        {
            //loop through pool and place entities
            //render scene
            for(int i = 0; i < entityPool.Count; ++i)
            {
                Instantiate(entityPool[i].getGameObject());
            }
            Console.WriteLine("Done");
        }

        void Start()
        {
            generateEntities("SceneDescriptor.csv");
        }
    }
}