using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class PeaBullet : Bullet
    {
        public PeaBullet(Vector2 posStart)
        {
            this.posStart = posStart; //vi tri bat dau ban dan
            //tao bullet model. vv gan idbullet ...
        }
    }
}
