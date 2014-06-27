using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class Plant : MainEntity
    {
        public enum PlantState { Stand, Attack, Sleep };
        
        public int xCell, yCell;
        public PlantModel model;
        public float hp;
        public string idPlant_stand;
        public string idPlant_sleep;
        public string idPlant_attack;
        public PlantState currentState = PlantState.Stand;

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
