using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class SpriteProvider
    {
        Dictionary<string, Sprite2D> dict = new Dictionary<string, Sprite2D>();

        public void Add(string id, Sprite2D sprite)
        {
            dict.Add(id, sprite);
        }

        public Sprite2D getSprite(String id)
        {
            if (dict.ContainsKey(id))
            {
                return dict[id];
            }
            return null;
        }
    }
}
