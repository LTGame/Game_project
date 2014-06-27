using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class GameModel
    {
        protected Sprite2D _mainSpite;
        protected float depth;
        
        public virtual void Update(GameTime gameTime)
        {
            if (_mainSpite != null)
                _mainSpite.update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_mainSpite != null)
                _mainSpite.draw(spriteBatch);
        }

        public virtual bool finishState()
        {
            return _mainSpite.Finish;
        }
    }
}
