using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public BulletModel model;
        public Vector2 vectorCollision; //noi va cham, can dc xet luc va cham

        public float maxPath = 200;//doan duong ma dan bay di
        public float currentPath = 0;
        public float dx = 1;
             

        public override void Update(GameTime gameTime)
        {
            currentPath += dx;
            if (currentPath >= maxPath)
                ;//lun di cho roi :D vi di qua xa
            if (currentState == BulletState.Collision && model.finishState())
                ;//cham nhau roi bien mat di thoi
            if (model != null)
                model.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (model != null)
                model.Draw(gameTime, spriteBatch);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
