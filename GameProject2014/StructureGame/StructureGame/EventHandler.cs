using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class EventHandler : InvisibleGameEntity
    {
        MouseHelper mousHelper = new MouseHelper();
        //KeyboardHelper keyboardHelper= new KeyboardHelper();

        Vector2 orginal = Vector2.Zero;
        float xtrans_orginal;
        float ytrans_orginal;
        bool click;//trang thai truoc do la nhap xuong nhung ko giu
        VisibleGameEntity currentHover = null;

        bool canHover;

        public bool CanHover
        {
            get { return canHover; }
            set { canHover = value; }
        }


        List<VisibleGameEntity> visible_entities = new List<VisibleGameEntity>();

        public EventHandler(List<VisibleGameEntity> visible_entities)
        {
            this.visible_entities = visible_entities;
        }

        void DrapScreen(GameTime gameTime)
        {
            mousHelper.Update(gameTime);

            if (mousHelper.IsLeftButtonDown())
            {
                if (mousHelper.HasLeftButtonDownEvent())
                {
                    orginal = mousHelper.GetCurrentViewPos();
                    xtrans_orginal = GameManager.currentScreen.Camera.XTrans;
                    ytrans_orginal = GameManager.currentScreen.Camera.YTrans;
                }
                float x = xtrans_orginal - orginal.X + mousHelper.GetCurrentViewPos().X;
                float y = ytrans_orginal - orginal.Y + mousHelper.GetCurrentViewPos().Y;
                GameManager.currentScreen.Camera.XTrans = x;
                GameManager.currentScreen.Camera.YTrans = y;

            }
        }

        private void Hover()
        {
            foreach (VisibleGameEntity entity in visible_entities)
            {
                if (entity.IsShow())
                {
                    VisibleGameEntity entiyhover = entity.Hover(mousHelper.GetCurrentWorldPos());
                    if (entiyhover != null)
                    {
                        if (currentHover != null && currentHover != entiyhover)
                            currentHover.setHover(false);
                        currentHover = entiyhover;
                        return;
                    }
                }
            }
        }

        private bool EventClick()
        {
            if (click && mousHelper.IsLeftButtonUp())
            {
                click = false;
                foreach (VisibleGameEntity entity in visible_entities)
                {
                    if (entity.IsShow())
                    {
                        VisibleGameEntity enity = entity.Click(mousHelper.GetCurrentWorldPos());
                    }
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
            DrapScreen(gameTime);
            if (canHover)
            {
                Hover();
                EventClick(); // ko nhap chung gi ca  
            }
        }
    }
}
