using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class SunModel : GameModel
    {
        Sun sun;

        public SunModel(Sun sun)
        {
            this.sun = sun;
            _mainSpite = GameManager.spriteProvider.getSprite(sun.idSun);
        }

        public override void Update(GameTime gameTime)
        {
            //ko bik ve nhu the nao tinh va ve di
            base.Update(gameTime);
        }
    }
}
