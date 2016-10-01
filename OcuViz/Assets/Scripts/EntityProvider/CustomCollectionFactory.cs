using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EntityProvider
{
    /// <summary>
    /// EntityFactory used to create a custom collection of data as specified by the user. 
    /// </summary>
    public class CustomCollectionFactory: EntityFactory //CustomCollection, EntityLink, C://InputFile.csv
    {
        /// <summary>
        /// The original Entity to be cloned and customised.
        /// </summary>
        private Entity original;

        /// <summary>
        /// File of the input file used to create the CustomCollection.
        /// </summary>
        private string filepath;

        /// <summary>
        /// Tokeniser used to break up lines of input into tokens.
        /// </summary>
        private Tokeniser tokeniser;

        /// <summary>
        /// The FileReader that's used to read the input file and return lines read.
        /// </summary>
        private FileReader reader;

        /// <summary>
        /// The original position of the prototype.
        /// </summary>
        private float oX, oY, oZ;

        /// <summary>
        /// The original dimensions of the prototype.
        /// </summary>
        private float dX, dY, dZ;

        /// <summary>
        /// The original colour of the prototype.
        /// </summary>
        private Color oColour;

        /// <summary>
        /// Method is used to set the prototype to be cloned as a base when creating
        /// the CustomCollection.
        /// </summary>
        /// <param name="proto">The entity to be cloned.</param>
        /// <param name="token">Tokeniser used to break up a read line.</param>
        /// <param name="read">FileReader to read all lines in the input file.</param>
        public void setOriginal(Entity proto, Tokeniser token, FileReader read)
        {
            original = proto;
            tokeniser = token;
            reader = read;

            reader = new FileReader();

            oX = original.getGameObject().transform.position.x;
            oY = original.getGameObject().transform.position.y;
            oZ = original.getGameObject().transform.position.z;

            dX = original.getGameObject().transform.localScale.x;
            dY = original.getGameObject().transform.localScale.y;
            dZ = original.getGameObject().transform.localScale.z;

            oColour = original.getGameObject().GetComponent<Renderer>().material.color;
        }

        /// <summary>
        /// Method builds the CustomCollection by reading the specified input file
        /// to get the values of the CustomCollection. 
        /// </summary>
        /// <param name="list">List containing EntityLink and input file name.</param>
        /// <returns>The CustomCollection specified by the input file.</returns>
        public override Entity build(string[] list) //posX, posY, posZ, dimX, dimY, dimZ, #colour
        {
            CustomCollection collection = new CustomCollection();
            Entity entity = new Entity();
            entity.setName(list[1]);
            filepath = list[2];
            List<string> lines = reader.getLines(filepath);

            float posX, posY, posZ;
            float dimX, dimY, dimZ;
            Color colour;

            foreach(string line in lines)
            {
                string[] parameters = tokeniser.tokenise(line);

                posX = float.Parse(parameters[0]);
                posY = float.Parse(parameters[1]);
                posZ = float.Parse(parameters[2]);

                dimX = (float.Parse(parameters[3]) == -1) ? dX : float.Parse(parameters[3]);
                dimY = (float.Parse(parameters[4]) == -1) ? dY : float.Parse(parameters[4]);
                dimZ = (float.Parse(parameters[5]) == -1) ? dZ : float.Parse(parameters[5]);

                if (parameters[6] == "null") colour = oColour;
                else ColorUtility.TryParseHtmlString(parameters[6], out colour);

                GameObject go = UnityEngine.Object.Instantiate(original.getGameObject());
                go.transform.position = new Vector3(posX, posY, posZ);
                go.transform.localScale = new Vector3(dimX, dimY, dimZ);
                go.GetComponent<Renderer>().material.color = colour;

                entity.setGameObject(go);
                collection.addEntity(entity);
            }
            return collection;
        }

        /// <summary>
        /// Requirement of the parent. This method should never be implemented, as it goes
        /// against creating a CustomCollection, which should only be created by an input
        /// file using the EntityProvider directly.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="entityLink"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            throw new NotImplementedException();
        }
    }
}
