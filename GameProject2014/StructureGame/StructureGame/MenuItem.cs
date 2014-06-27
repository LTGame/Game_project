using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class MenuItem : VisibleGameEntity
    {
        Sprite2D normal, hover, actived;

        public delegate void ClickEvent();
        ClickEvent click = null;
        bool active = false;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public MenuItem(Vector2 pos, ClickEvent click, Sprite2D normal, Sprite2D hover, float depth)
        {
            this.normal = normal;
            this.hover = hover;

            this.normal.Entity = this;
            this.hover.Entity = this;

            this.click = click;
            this.currentSprite = normal;
            this.depth = depth;
        }

        public MenuItem(Vector2 pos, ClickEvent click, Sprite2D normal, Sprite2D hover, Sprite2D actived, float depth)
        {
            this.normal = normal;
            this.hover = hover;
            this.actived = actived;

            this.normal.Entity = this;
            this.hover.Entity = this;
            this.actived.Entity = this;

            this.click = click;
            this.currentSprite = normal;
            this.depth = depth;
        }

        public override VisibleGameEntity Click(Vector2 worldPos)
        {
            if (currentSprite.hover(worldPos) && click != null)
            {
                click();
                return this;
            }
            return null;
        }

        public override void setHover(bool h)
        {
            if (h == true)
            {
                this.currentSprite = hover;
            }
            else
            {
                this.currentSprite = normal;
            }
        }

        public override VisibleGameEntity Hover(Vector2 worldPos)
        {
            if (currentSprite.hover(worldPos))
            {
                this.currentSprite = hover;
                return this;
            }
            else
            {
                this.currentSprite = normal;
                return null;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (active && actived != null)
                this.currentSprite = actived;
        }
    }
}
