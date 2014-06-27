using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class IdieCamera : AbstractCamera
    {
        public override void Update(GameTime gameTime)
        {

        }

        public override Vector2 View2World(Vector2 viewPos)
        {
            return viewPos;
        }

        public override Vector2 World2View(Vector2 worldPos)
        {
            return worldPos;
        }
    }
}
