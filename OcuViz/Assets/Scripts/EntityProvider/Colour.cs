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
            ColorUtility.TryParseHtmlString(hex, out colour);
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
