using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class KeyboardHelper : InvisibleGameEntity
    {
        Keys _key;

        public Keys Key
        {
            get { return _key; }
            set { _key = value; }
        }

        KeyboardState currentState, prevState;

        public KeyboardHelper(Keys key)
        {
            this._key = key;
        }

        public void getNewKeyState(KeyboardState state)
        {
            prevState = currentState;
            currentState = state;
        }

        public bool IsKeyDown()
        {
            return currentState.IsKeyDown(_key);
        }

        public bool IsKeyUp()
        {
            return currentState.IsKeyUp(_key);
        }

        public bool HasKeyDown()
        {
            if (prevState.IsKeyUp(_key) && currentState.IsKeyDown(_key))
            {
                return true;
            }
            return false;
        }

        public bool HasKeyUp()
        {
            if (prevState.IsKeyDown(_key) && currentState.IsKeyUp(_key))
            {
                return true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            getNewKeyState(Keyboard.GetState());
        }
    }
}
