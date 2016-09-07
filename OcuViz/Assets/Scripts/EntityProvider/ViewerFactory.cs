using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EntityProvider
{
    class ViewerFactory: EntityFactory
    {
        public override Entity build(string[] list)
        {
            throw new NotImplementedException();
        }

        public override Entity buildBasic(string button, string entityLink, string type)
        {
            throw new NotImplementedException();
        }
    }
}
