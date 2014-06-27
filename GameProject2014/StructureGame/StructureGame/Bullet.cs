using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public abstract class Bullet : MainEntity
    {
        public enum BulletState { Fly, Collision }

        public BulletState currentState;
        public float damage;
        public string idBullet_fly;
        public string idBullet_collision;
        public Vector2 posStart;
    }
}
