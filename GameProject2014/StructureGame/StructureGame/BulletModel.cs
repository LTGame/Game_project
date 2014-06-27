using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class BulletModel : GameModel
    {
        Sprite2D spriteFly;
        Sprite2D spriteCollision;

        Bullet bullet;
        public BulletModel(Bullet bullet)
        {
            this.bullet = bullet;
            spriteCollision = GameManager.spriteProvider.getSprite(bullet.idBullet_collision);
            spriteFly = GameManager.spriteProvider.getSprite(bullet.idBullet_collision);
            this._mainSpite = spriteFly;
            this._mainSpite.Vector = bullet.posStart;
        }

        public override void Update(GameTime gameTime)
        {
            if (bullet.currentState == Bullet.BulletState.Fly)
            {
                this._mainSpite.Vector = new Vector2(bullet.posStart.X + bullet.currentPath, bullet.posStart.Y);
                this._mainSpite = spriteFly;
            }
            else if (bullet.currentState == Bullet.BulletState.Collision)
                this._mainSpite = spriteCollision;
            base.Update(gameTime);
        }
    }
}
