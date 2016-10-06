using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EntityProvider
{
    /// <summary>
    /// This class is used to handle colour creation used in the scene by GameObjects.
    /// </summary>
    public class Colour
    {
        /// <summary>
        /// Constructor. Creates a colour based on the name of the colour requested, 
        /// or the hexadecimal colour provided to the constructor.
        /// </summary>
        /// <param name="n">The name of the colour. If this is detected to be a name of
        /// a colour already known, then the hexadecimal value is ignored and a default 
        /// value is used to colour the GameObject.</param>
        /// <param name="hex">The hexadecimal value of the colour. This will be used if 
        /// the name provided to the constructor is not recognised.</param>
        public Colour(string n, string hex)
        {
            if (n == null) throw new ArgumentNullException("n", "Name of colour cannot be null.");
            if (hex == null) throw new ArgumentNullException("hex", "Colour hexadecimal value cannot be null.");
            name = n;
            if (n == "black") colour = Color.black;
            else if (n == "blue") colour = Color.blue;
            else if (n == "clear") colour = Color.clear;
            else if (n == "cyan") colour = Color.cyan;
            else if (n == "gray") colour = Color.gray;
            else if (n == "green") colour = Color.green;
            else if (n == "grey") colour = Color.grey;
            else if (n == "magenta") colour = Color.magenta;
            else if (n == "red") colour = Color.red;
            else if (n == "white") colour = Color.white;
            else if (n == "yellow") colour = Color.yellow;
            else
            {
                Color makebelieve = new Color();
                if (!ColorUtility.TryParseHtmlString(hex, out makebelieve)) throw new InvalidColourHexException();
                ColorUtility.TryParseHtmlString(hex, out colour);
            }
        }

        /// <summary>
        /// Color object that will be used to render the GameObjects
        /// </summary>
        protected Color colour;

        /// <summary>
        /// The name of the colour.
        /// </summary>
        protected string name;


        /// <summary>
        /// Returns the Color object. This method should be used to
        /// retrieve the value stored for colouring GameObjects.
        /// </summary>
        /// <returns>Unity Color object.</returns>
        public Color getColour()
        {
            return colour;
        }

        /// <summary>
        /// Returns the name of the colour.
        /// </summary>
        /// <returns>Colour name.</returns>
        public string getName()
        {
            return name;
        }
    }
}
