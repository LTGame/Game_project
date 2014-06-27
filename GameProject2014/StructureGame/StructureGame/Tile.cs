using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class Tile : VisibleGameEntity
    {
        Sprite2D spritesTile;

        internal Sprite2D SpritesTile
        {
            get { return spritesTile; }
            set { spritesTile = value; }
        }

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        List<int> nextTiles;

        public List<int> NextTiles
        {
            get { return nextTiles; }
            set { nextTiles = value; }
        }

        public Tile(Sprite2D sprites_tile, int id, List<int> nexttiles, float depth)
        {
            this.spritesTile = sprites_tile;
            this.id = id;
            this.nextTiles = nexttiles;
            sprites_tile.Entity = this;
            this.depth = depth;
        }

        public override void Update(GameTime gameTime)
        {
            spritesTile.update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 pos)
        {
            spritesTile.Vector = pos;
            spritesTile.draw(spriteBatch);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 pos, Color color)
        {
            spritesTile.Vector = pos;
            spritesTile.draw(spriteBatch,color,Vector2.Zero,1f);
        }
    }
}
