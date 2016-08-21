using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    class Collection: Entity //should be composite, as decorator needs Entity to be an interface. That wouldn't work too well.
    {
        private List<Entity> collection;
        private Entity original;
        private string type;
        private int dimension;
        private float xPos;
        private float yPos;
        private float zPos;

        public Collection()
        {
            collection = new List<Entity>();
        }

        public override void handleAttributes(List<string> attributes)
        {

        }

        public void createCollection()
        {
            //handle transforms, etc.
            //EntityProvider.renderScene() will call this to delegate building the entities
        }

        public void setEntity(Entity entity)
        {
            original = entity;
        }

        public void setType(string ty)
        {
            type = ty;
        }

        public void setDimension(int di)
        {
            dimension = di;
        }

        public void setPos(float x, float y, float z)
        {
            xPos = x;
            yPos = y;
            zPos = z;
        }
    }
}
