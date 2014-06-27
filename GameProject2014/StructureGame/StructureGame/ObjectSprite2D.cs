using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class ObjectSprite2D : Sprite2D
    {
        private Vector2 tempVector = Vector2.Zero; // vector ho tro di chuyen loop 

        public ObjectSprite2D(List<MyTexture> textures, int elapsedTime, int cycle, Vector2 transition, Vector2 center)
            : base(textures,Vector2.Zero, elapsedTime,cycle,transition)
        {
            this.Center = center;
        }

        public ObjectSprite2D(MyTexture texture, Vector2 center)
            : base(texture, Vector2.Zero)
        {
            this.Center = center;
        }

        public ObjectSprite2D(List<MyTexture> textures, int elapsedTime, Vector2 center)
            : base(textures, Vector2.Zero, elapsedTime)
        {
            this.Center = center;
        }

        public override void update(GameTime gameTime)
        {
            if (textures.Count > 2)
            {
                i--;
                if (i < 0)
                {
                    i = elapsedTime;
                    index++;
                    if (loop == false && index == textures.Count)
                    {
                        cycle++;              
                        if (cycle >= maxCycle)
                        {
                            tempVector = Vector2.Zero;
                            index = index-1;
                            finish = true;
                        }
                        else
                            tempVector = new Vector2(transition.X + tempVector.X, transition.Y + tempVector.Y);
                    }
                }
                index = index % textures.Count;
                
            }
            if (Entity != null && Entity is MainEntity)
                vector = GameManager.currentScreen.Map.getTileCentroid(((MainEntity)Entity).IndexMap) - this.Center + tempVector;
        }

        public override Sprite2D Clone()
        {
            return new ObjectSprite2D(textures, elapsedTime, cycle, transition, center);
        }
    }
}
