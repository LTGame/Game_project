using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class Index
    {
        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Index(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Map Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
