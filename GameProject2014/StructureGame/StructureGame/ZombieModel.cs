using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class ZombieModel : GameModel
    {
        Zombie zombie;
        Sprite2D spriteRunning;
        Sprite2D spriteEating;
        Sprite2D spriteDie;

        public ZombieModel(Zombie zombie)
        {
            this.zombie = zombie;
            this.spriteDie = GameManager.spriteProvider.getSprite(zombie.idZombie_die);
            this.spriteEating = GameManager.spriteProvider.getSprite(zombie.idZombie_eating);
            this.spriteRunning = GameManager.spriteProvider.getSprite(zombie.idZombie_running);
            float x = 0;//tinh toa do x tren map theo zombie.row
            float y = 0;//toa do khoi dau tren cot y
            this._mainSpite.Vector = new Vector2(x, y);

            this._mainSpite = spriteRunning;
        }

        public override void Update(GameTime gameTime)
        {
      
            if(zombie.currentState == Zombie.ZombieState.Die)
                this._mainSpite = spriteDie;
            else if (zombie.currentState == Zombie.ZombieState.Running)
                this._mainSpite = spriteRunning;
            else if (zombie.currentState == Zombie.ZombieState.Eating)
                this._mainSpite = spriteEating;

            base.Update(gameTime);
        }
    }
}
