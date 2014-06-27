using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public abstract class Stage
    {
        Screen screen;

        public Stage(Screen screen)
        {
            this.screen = screen;
        }

        public abstract void Update(GameTime gameTime);
    }
}
