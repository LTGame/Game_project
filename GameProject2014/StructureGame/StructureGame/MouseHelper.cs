using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    class MouseHelper : InvisibleGameEntity
    {
        private MouseState CurrentState, PrevState;

        public void PressNewState(MouseState mouseState)
        {
            this.PrevState = CurrentState;
            this.CurrentState = mouseState;
        }

        public bool HasRightButtonDownEvent()
        {
            if (PrevState.RightButton == ButtonState.Released &&
                CurrentState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool HasRightButtonUpEvent()
        {
            if (PrevState.RightButton == ButtonState.Pressed &&
                CurrentState.RightButton == ButtonState.Released)
                return true;
            return false;
        }

        public bool IsRightButtonDown()
        {
            return CurrentState.RightButton == ButtonState.Pressed;
        }

        public bool IsRightButtonUp()
        {
            return CurrentState.RightButton == ButtonState.Released;
        }

        public Vector2 GetCurrentViewPos()
        {
            return new Vector2(CurrentState.X, CurrentState.Y);
        }

        public Vector2 GetCurrentWorldPos()
        {
            return GameManager.currentScreen.Camera.View2World(new Vector2(CurrentState.X, CurrentState.Y));
        }

        public bool HasLeftButtonDownEvent()
        {
            if (PrevState.LeftButton == ButtonState.Released &&
                CurrentState.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool HasLeftButtonUpEvent()
        {
            if (PrevState.LeftButton == ButtonState.Pressed &&
                CurrentState.LeftButton == ButtonState.Released)
                return true;
            return false;
        }

        public bool IsLeftButtonDown()
        {
            return CurrentState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftButtonUp()
        {
            return CurrentState.LeftButton == ButtonState.Released;
        }

        public override void Update(GameTime gameTime)
        {
            PressNewState(Mouse.GetState());
        }
    }
}
