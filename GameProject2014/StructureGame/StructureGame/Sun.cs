using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class Sun : MainEntity
    {
        public enum SunState { Falling, Idle, PickUp}

        public String idSun;
        public SunState currentState = SunState.Falling;
        public int energy;
        public SunModel model;
        public int Type; //1 = duong cong khi hoa mat troi mat ra, 2 tren troi roi xuong duong thang

        public override void Update(GameTime gameTime)
        {
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
