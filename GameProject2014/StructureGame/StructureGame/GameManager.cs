using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace StructureGame
{
    class GameManager
    {
        static public SpriteProvider spriteProvider = null;
        static public Screen currentScreen = null;
        static public bool ExitGame = false;
    }
}
