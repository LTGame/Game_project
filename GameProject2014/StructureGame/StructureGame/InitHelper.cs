using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace StructureGame
{
    public class InitHelper
    {
        public static bool Init(ContentManager Content)
        {
            if (Content == null)
                return false;

            return true;
        }

    }
}
