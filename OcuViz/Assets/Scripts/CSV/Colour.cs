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

            string[] splitColours = hex.Split('-');
            float r = Convert.ToInt32(splitColours[0]) / 256;
            float g = Convert.ToInt32(splitColours[1]) / 256;
            float b = Convert.ToInt32(splitColours[2]) / 256;

            colour = new Color(r, g, b);
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
