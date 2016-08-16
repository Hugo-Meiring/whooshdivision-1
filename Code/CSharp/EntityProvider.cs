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
        private GameObject newGameObject;
        private string[] list;
        private Tokeniser tokeniser = new CommaTokeniser();
        private FileReader reader = new FileReader();
        private FactoryShop factoryShop = new FactoryShop();
        private List<string> listRead;
        public string[] getEntity;

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
                    string[] splitColours = list[1].Split(' ');
                    Colour color = new Colour(list[1], list[2]);

                    Color background = color.getColour();
                    Camera camera = GetComponent<Camera>();

                    camera.clearFlags = CameraClearFlags.SolidColor;
                    camera.backgroundColor = background;
                }

                else if (list[0] == "Colour")
                {

                    //do some major magic to link to the entity in question, if it exists
                }

                else if (list[0] == "Texture")
                {
                    //TODO
                }

                else if (list[0] == "Attributes")
                {

                }

                else if(list[0] == "Variables")
                {

                }

                else
                {
                    entityFactory = factoryShop.getFactory(list[0]);
                    newGameObject = entityFactory.build(list);
                    Entity parent = getEntityParent(list[2]);
                    Entity newEntity = new Entity();
                    newEntity.setName(list[1]);
                    newEntity.setGameObject(newGameObject);
                    newEntity.setParent(parent);
                    entityPool.Add(newEntity); // or attach to entity
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
        }
    }
}