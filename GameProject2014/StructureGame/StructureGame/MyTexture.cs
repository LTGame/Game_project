using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class MyTexture
    {
        Texture2D texture;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        Rectangle boundary;

        public Rectangle Boundary
        {
            get { return boundary; }
            set { boundary = value; }
        }

        public MyTexture(Texture2D texture, Rectangle boundary)
        {
            this.texture = texture;
            this.boundary = boundary;
        }

        public MyTexture(Texture2D texture)
        {
            this.texture = texture;
            this.boundary = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public Sprite2D Sprite2D
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
