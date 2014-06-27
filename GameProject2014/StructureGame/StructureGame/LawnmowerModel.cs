using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class LawnmowerModel : GameModel
    {
        Lawnmower lawnmower;
        Vector2 initial; //vector luc khoi tao
        public LawnmowerModel(Lawnmower lawnmower)
        {
            this.lawnmower = lawnmower;
            this._mainSpite = GameManager.spriteProvider.getSprite(lawnmower.idLawnmower);
            float x = 0;//tinh toa x dum cai
            float y = 0;// tinh toa y dum cai
            this._mainSpite.Vector = new Vector2(x, y);
            initial = new Vector2(x, y);
        }

        public override void Update(GameTime gameTime)
        {
            if (lawnmower.currentState == Lawnmower.LawnmowerState.Running)
                this._mainSpite.Vector = new Vector2(initial.X + lawnmower.currentPath, initial.Y); //xe dich chuyen theo truc x

            base.Update(gameTime);
        }
    }
}
