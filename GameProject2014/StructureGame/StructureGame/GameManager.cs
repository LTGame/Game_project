using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace StructureGame
{
    class GameManager
    {
        static public SpriteProvider spriteProvider = null;
        static public ObjectProvider objectProvider = null;
        static public QuestionProvider questionProvider = null;
        static public Screen currentScreen = null;

        static public SpriteFont font = null;
        static public SpriteFont fontInfo = null;
        static public Song bgMusic;
        static public SoundEffect coin;

        static public Character playingCharacter = null;
        static public bool endTurn = false;

        static public int nCols = 10;
        static public int nRows = 10;
        static public int nObject = 10;
        static public int nTreasure = 5;

        static public string level = "de";
        static public string music = "vua";
        static public string sound = "vua";

        static public float volume = 0.5f;
        static public float volumeSound = 0.5f;

        static public bool ExitGame = false;
    }
}
