using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public abstract class Screen
    {
        protected Sprite2D background = null;
        protected AbstractCamera camera = new IdieCamera();
        protected Map map = null;
        protected Interaction interaction = null;

        public Map Map
        {
            get { return map; }
            set { map = value; }
        }

        protected List<VisibleGameEntity> list_enity = new List<VisibleGameEntity>();

        public List<VisibleGameEntity> List_enity
        {
            get { return list_enity; }
            set { list_enity = value; }
        }
        protected List<VisibleGameEntity> menuContexts = new List<VisibleGameEntity>();

        public AbstractCamera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        protected EventHandler eventHandler = null;
        protected ContextEventHandler contextEventHandler = null;
        protected Dialog dialog = null;

        public Dialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (dialog != null)
            {
                dialog.Update(gameTime);
            }
            else
            {
                if (contextEventHandler != null)
                    contextEventHandler.Update(gameTime);
                if (eventHandler != null)
                {
                    if (contextEventHandler != null)
                    {
                        eventHandler.CanHover = !contextEventHandler.FinishHover;
                    }
                    else
                    {
                        eventHandler.CanHover = true;
                    }

                    eventHandler.Update(gameTime);
                }
                if (interaction != null)
                    interaction.Update(gameTime);
                if (map != null)
                    map.Update(gameTime);
                if (camera != null)
                    camera.Update(gameTime);
            }
            foreach (VisibleGameEntity entity in list_enity)
            {
                entity.Update(gameTime);
            }

            if (background != null)
                background.update(gameTime);

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (VisibleGameEntity entity in list_enity)
            {
                entity.Draw(gameTime, spriteBatch);
            }

            if (map != null)
                map.Draw(gameTime, spriteBatch);

            if (background != null)
                background.draw(spriteBatch,0.9f);
        }


        //khong su dung camera, doi tuong se giu co dinh tren mang hinh
        public virtual void Draw2(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (VisibleGameEntity menu in menuContexts)
            {
                menu.Draw(gameTime, spriteBatch);
            }

            if (dialog != null)
            {
                dialog.Draw(gameTime, spriteBatch);
            }
        }
    }
}
