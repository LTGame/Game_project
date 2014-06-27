using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class PlantModel : GameModel
    {
        Plant plant;
        Sprite2D spriteAttack;
        Sprite2D spriteStand;
        Sprite2D spriteSleep;
        Plant.PlantState oldState;

        public PlantModel(Plant plant)
        {
            this.plant = plant;

            float x = 0;//tinh toa do x tren map theo plant.yCell
            float y = 0;//tinh toa do y tren map theo plant.xCell
            Vector2 position = new Vector2(x, y);

            this.spriteAttack = GameManager.spriteProvider.getSprite(plant.idPlant_attack);
            this.spriteAttack.Vector = position;
            this.spriteSleep = GameManager.spriteProvider.getSprite(plant.idPlant_sleep);
            this.spriteSleep.Vector = position;
            this.spriteStand = GameManager.spriteProvider.getSprite(plant.idPlant_stand);
            this.spriteStand.Vector = position;

            this._mainSpite = this.spriteStand;
        }

        public override void Update(GameTime gameTime)
        {
            if (plant.currentState == Plant.PlantState.Stand)
                this._mainSpite = this.spriteStand;
            else if (plant.currentState == Plant.PlantState.Sleep)
                this._mainSpite = this.spriteSleep;
            else if (plant.currentState == Plant.PlantState.Attack && oldState != Plant.PlantState.Attack)
            {     
                this._mainSpite = this.spriteAttack;
                this._mainSpite.Run();
            }
            oldState = plant.currentState;
            base.Update(gameTime);
        }
    }
}
