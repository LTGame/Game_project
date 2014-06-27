using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class VisibleGameEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        protected Sprite2D currentSprite;

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (currentSprite != null)
                currentSprite.draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (currentSprite != null)
                currentSprite.update(gameTime);
        }

        public virtual bool IsShow()
        {
            return true;
        }

        public virtual VisibleGameEntity Click(Vector2 worldPos)
        {
            return null;
        }


        public virtual VisibleGameEntity Hover(Vector2 worldPos)
        {
            return null;
        }


        public virtual void setHover(bool hover)
        {

        }

        protected float depth;

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }
    }
}
