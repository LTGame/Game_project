using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class RedLawnmower : Lawnmower
    {
        public RedLawnmower(int row)
        {
            this.idLawnmower = "RedLawnmower";
            this.row = row;
            this.model = new LawnmowerModel(this);
        }
    }
}
