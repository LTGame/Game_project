using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class Dialog : VisibleGameEntity
    {
        protected List<VisibleGameEntity> list_entity_dialog = new List<VisibleGameEntity>();
        protected ContextEventHandler handler;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (VisibleGameEntity enity in list_entity_dialog)
            {
                enity.Draw(gameTime, spriteBatch);
            }
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if(handler != null)
                handler.Update(gameTime);
            foreach (VisibleGameEntity enity in list_entity_dialog)
            {
                enity.Update(gameTime);
            }
            base.Update(gameTime);
        }
    }
}
