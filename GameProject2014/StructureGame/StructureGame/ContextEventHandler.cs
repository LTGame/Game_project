using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class ContextEventHandler : InvisibleGameEntity
    {
        MouseHelper mousHelper = new MouseHelper();
        //KeyboardHelper keyboardHelper= new KeyboardHelper();

        bool click;
        VisibleGameEntity currentHover = null;


        List<VisibleGameEntity> visible_entities = new List<VisibleGameEntity>();

        public ContextEventHandler(List<VisibleGameEntity> visible_entities)
        {
            this.visible_entities = visible_entities;
        }

        bool finishClick;

        public bool FinishClick
        {
            get { return finishClick; }
            set { finishClick = value; }
        }

        bool finishHover;

        public bool FinishHover
        {
            get { return finishHover; }
            set { finishHover = value; }
        }


        private bool Hover()
        {
            foreach (VisibleGameEntity entity in visible_entities)
            {
                if (entity.IsShow())
                {
                    VisibleGameEntity entiyhover = entity.Hover(mousHelper.GetCurrentViewPos());
                    if (entiyhover != null)
                    {
                        if (currentHover != null && currentHover != entiyhover)
                            currentHover.setHover(false);
                        currentHover = entiyhover;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool EventClick()
        {
            if (click && mousHelper.IsLeftButtonUp())
            {
                click = false;
                foreach (VisibleGameEntity entity in visible_entities)
                {
                    if (entity.IsShow() && entity.Click(mousHelper.GetCurrentViewPos()) != null)
                        return true;
                }
            }
            if (mousHelper.IsLeftButtonDown())
            {
                click = true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            mousHelper.Update(gameTime);
            finishHover = Hover();
            finishClick = EventClick();
        }
    }
}
