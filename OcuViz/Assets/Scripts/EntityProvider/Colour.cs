using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EntityProvider
{
    class Colour
    {
        public Colour(string n, string hex)
        {
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
            else ColorUtility.TryParseHtmlString(hex, out colour);
        }

        protected Color colour;
        protected string name;


        public Color getColour()
        {
            return colour;
        }

        public string getName()
        {
            return name;
        }
    }
}
