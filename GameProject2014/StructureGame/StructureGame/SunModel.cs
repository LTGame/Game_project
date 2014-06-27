using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
