using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class Coin : MainEntity
    {
        public enum CoinState { Falling, Idle, PickUp}
        public CoinState currentState = CoinState.Falling;

        public string idCoin;
        public float monney;
        public CoinModel model;
        public Vector2 posStart;

        public float FallingMaxPath = 20;
        public float dy = 0.05f;
        public float currentFallingPath = 0;

        float maxTime = 100000;//20 giay
        float tick = 0;

        public override void Update(GameTime gameTime)
        {
            tick++;
            if (tick >= maxTime)
                ;//xoa di thoi de lam gi
            if (currentState == CoinState.Falling)
            {
                currentFallingPath += dy;
                if (currentFallingPath >= FallingMaxPath)
                    currentState = CoinState.Idle;
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
