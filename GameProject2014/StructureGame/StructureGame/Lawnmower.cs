using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class Lawnmower : MainEntity
    {
        public enum LawnmowerState { Idle, Running }

        public LawnmowerState currentState;
        public int row;
        public float maxPath = 2000; //doan duong ma cai nay no di
        public float currentPath = 0;//doan duong da di
        public float dx = 1;

        public LawnmowerModel model = null;
        public string idLawnmower;


        public override void Update(GameTime gameTime)
        {
            if (this.currentState == LawnmowerState.Running)
            {
                currentPath += dx;
                if (currentPath >= maxPath)
                    ;//xoa Lawnmower ngay di thoi
            }
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
