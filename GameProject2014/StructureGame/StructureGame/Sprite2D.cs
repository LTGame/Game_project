using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class Sprite2D
    {
        protected List<MyTexture> textures;
        protected int index = 0;

        protected Vector2 vector;

        protected int elapsedTime;
        protected int i = 0; // bien chay cho elapsedTime

        protected bool loop;
        protected int maxCycle;
        protected int cycle;
        protected bool finish;
        protected Vector2 transition;
        protected Vector2 center;

        private float depth;

        protected float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }

        public bool Finish
        {
            get { return finish; }
            set { finish = value; }
        }

        public Vector2 Vector
        {
            get { return vector; }
            set
            {
                vector = value;
            }
        }

    

        public Sprite2D(List<MyTexture> textures, Vector2 vector, int elapsedTime)
        {
            this.textures = textures;
            this.vector = vector;
            this.elapsedTime = elapsedTime;
            this.i = this.elapsedTime;
            this.loop = true;
            this.finish = true;
        }

        public Sprite2D(List<MyTexture> textures, Vector2 vector, int elapsedTime, int cycle, Vector2 transition)
        {
            this.textures = textures;
            this.vector = vector;
            this.elapsedTime = elapsedTime;
            this.i = this.elapsedTime;
            this.loop = false;
            this.maxCycle = cycle;
            this.cycle = 0;
            this.finish = false;
            this.transition = transition;
        }

        public Sprite2D(MyTexture texture, Vector2 vector)
        {
            this.textures = new List<MyTexture>();
            this.textures.Add(texture);

            this.vector = vector;
            this.elapsedTime = 10;
            this.i = this.elapsedTime;
            this.loop = true;
            this.finish = true;
        }

        public virtual void draw(SpriteBatch batch)
        {
            batch.Draw(textures[index].Texture, vector, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, depth);
        }

        public virtual void draw(SpriteBatch batch, Color color, Vector2 origin, float scale)
        {
            batch.Draw(textures[index].Texture, vector, null, color, 0, origin, scale, SpriteEffects.None, depth);
        }

        public virtual void update(GameTime gameTime)
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
                        vector = new Vector2(transition.X + vector.X, transition.Y + vector.Y);
                        if (cycle >= maxCycle)
                            finish = true;
                    }
                }
                index = index % textures.Count;
            }
        }

        public virtual bool hover(Vector2 v)
        {
            Rectangle boundary = textures[index].Boundary;
            if (v.X >= this.vector.X + boundary.X && v.X <= this.vector.X + boundary.X + boundary.Width
                && v.Y >= this.vector.Y + boundary.Y && v.Y <= this.vector.Y + boundary.Y + boundary.Height)
                return true;
            return false;
        }

        public virtual void Run()
        {
            if (!loop)
            {
                index = 0;
                cycle = 0;
                finish = false;
            }
        }


        public virtual Sprite2D Clone()
        {
           return new Sprite2D(textures, vector, elapsedTime, cycle, transition);
        }
    }
}
