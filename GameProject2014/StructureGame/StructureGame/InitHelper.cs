using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace StructureGame
{
    public class InitHelper
    {
        public static bool Init(ContentManager Content)
        {
            if (Content == null)
                return false;

            InitSpriteProvider(Content);
            InitObjectProvider(Content);
            GameManager.font = Content.Load<SpriteFont>("spriteFont1");
            GameManager.fontInfo = Content.Load<SpriteFont>("FontInfo");

            GameManager.questionProvider = new QuestionProvider();
            GameManager.questionProvider.Load("Question.xml");

            GameManager.coin = Content.Load<SoundEffect>("coin");
            GameManager.bgMusic = Content.Load<Song>("music3");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = GameManager.volume;
            MediaPlayer.Play(GameManager.bgMusic);

            GameManager.currentScreen = new IntroScreen();
            return true;
        }

        private static void InitObjectProvider(ContentManager Content)
        {
            GameManager.objectProvider = new ObjectProvider();
             ObjectSprite2D sSmallRock = (ObjectSprite2D) GameManager.spriteProvider.getSprite("smallRock");
             GameObject object1 = new GameObject(sSmallRock,0.05f);
             sSmallRock.Entity = object1;
             GameManager.objectProvider.Add("smallRock", object1);

             ObjectSprite2D sBigRock = (ObjectSprite2D)GameManager.spriteProvider.getSprite("bigRock");
             GameObject object2 = new GameObject(sBigRock,0.05f);
             sBigRock.Entity = object2;
             GameManager.objectProvider.Add("bigRock", object2);

             ObjectSprite2D sTree1 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("tree1");
             GameObject object3 = new GameObject(sTree1,0.05f);
             sTree1.Entity = object3;
             GameManager.objectProvider.Add("tree1", object3);

             ObjectSprite2D sTree2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("tree2");
             GameObject object4 = new GameObject(sTree2,0.05f);
             sTree2.Entity = object4;
             GameManager.objectProvider.Add("tree2", object4);

             Index[] idRiver = new Index[9];
             idRiver[0] = new Index(-1, -1);
             idRiver[1] = new Index(-1, 0);
             idRiver[2] = new Index(-1, 1);
             idRiver[3] = new Index(0, -1);
             idRiver[4] = new Index(0, 0);
             idRiver[5] = new Index(0, 1);
             idRiver[6] = new Index(1, -1);
             idRiver[7] = new Index(1, 0);
             idRiver[8] = new Index(1, 1);
             ObjectSprite2D sRiver = (ObjectSprite2D)GameManager.spriteProvider.getSprite("river");
             GameObject object5 = new GameObject(sRiver,idRiver,0.05f);
             sRiver.Entity = object5;
             GameManager.objectProvider.Add("river", object5);
        }

        private static void InitSpriteProvider(ContentManager Content)
        {
            GameManager.spriteProvider = new SpriteProvider();
            Texture2D texture = Content.Load<Texture2D>("tile/glass");
            GameManager.spriteProvider.Add("glass", new Sprite2D(new MyTexture(texture), Vector2.Zero));

            //load Object
            ObjectSprite2D sSmallRock = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Object/smallRock")), new Vector2(29,34));
            GameManager.spriteProvider.Add("smallRock", sSmallRock);
            ObjectSprite2D sBigRock = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Object/bigRock")), new Vector2(32, 44));
            GameManager.spriteProvider.Add("bigRock", sBigRock);
            ObjectSprite2D sTree1 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Object/tree1")), new Vector2(28, 114));
            GameManager.spriteProvider.Add("tree1", sTree1);
            ObjectSprite2D sTree2 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Object/tree2")), new Vector2(32, 144));
            GameManager.spriteProvider.Add("tree2", sTree2);
            ObjectSprite2D sRiver = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Object/river")), new Vector2(72, 39));
            GameManager.spriteProvider.Add("river", sRiver);


            //load treasure
            ObjectSprite2D sTreasure = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/treasure")), new Vector2(24, 30));
            GameManager.spriteProvider.Add("Treasure", sTreasure);
            Sprite2D sTitan = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/titan")), new Vector2(130, 145));
            GameManager.spriteProvider.Add("Titan", sTitan);
            Sprite2D sSilver = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/silver")), new Vector2(130, 145));
            GameManager.spriteProvider.Add("Silver", sSilver);
            Sprite2D sDiamond = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/diamon")), new Vector2(130, 145));
            GameManager.spriteProvider.Add("Diamond", sDiamond);
            Sprite2D sGold = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/gold")), new Vector2(130, 145));
            GameManager.spriteProvider.Add("Gold", sGold);
            Sprite2D sSaturn = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/SaturnBook")), new Vector2(299, 145));
            GameManager.spriteProvider.Add("SaturnBook", sSaturn);
            Sprite2D sVenus = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/VenusBook")), new Vector2(299, 145));
            GameManager.spriteProvider.Add("VenusBook", sVenus);
            Sprite2D sMars= new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/MarsBook")), new Vector2(299, 145));
            GameManager.spriteProvider.Add("MarsBook", sMars);
            Sprite2D sMecury= new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/MecuryBook")), new Vector2(299, 145));
            GameManager.spriteProvider.Add("MecuryBook", sMecury);
            Sprite2D sTreasureDialog = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/TreasureDialog")), new Vector2(62, 48));
            GameManager.spriteProvider.Add("TreasureDialog", sTreasureDialog);
            Sprite2D sManual = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/manual")), new Vector2(475, 145));
            GameManager.spriteProvider.Add("Manual", sManual);
            Sprite2D sNonManual = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/NonManual")), new Vector2(475, 145));
            GameManager.spriteProvider.Add("NonManual", sNonManual);
            Sprite2D sNonBook = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/NonBook")), new Vector2(299, 145));
            GameManager.spriteProvider.Add("NonBook", sNonBook);
            Sprite2D sNonTreasure = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/NonTreasure")), new Vector2(130, 145));
            GameManager.spriteProvider.Add("NonTreasure", sNonTreasure);
            Sprite2D sbuttonDialog = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/button_dialog")), new Vector2(569, 74));
            GameManager.spriteProvider.Add("button_dialog", sbuttonDialog);
            Sprite2D sQuestionDialog = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/Question_Dialog")), new Vector2(62, 48));
            GameManager.spriteProvider.Add("QuestionDialog", sQuestionDialog);
            Sprite2D sBlackRound = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/BlackRound")),Vector2.Zero);
            GameManager.spriteProvider.Add("BlackRound", sBlackRound);
            Sprite2D sRedRound = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Treasure/RedRound")), Vector2.Zero);
            GameManager.spriteProvider.Add("RedRound", sRedRound);

            //load game
            Sprite2D sFrame = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/frame")), new Vector2(0,362));
            GameManager.spriteProvider.Add("Frame", sFrame);
            Sprite2D sObjectInfor = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/ObjectInfor")), Vector2.Zero);
            GameManager.spriteProvider.Add("ObjectInfor", sObjectInfor);
            Sprite2D sGameover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/GAME OVER")), Vector2.Zero);
            GameManager.spriteProvider.Add("GameOver", sGameover);
            Sprite2D sItem1 = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item1")), new Vector2(290,180));
            GameManager.spriteProvider.Add("Item1", sItem1);
            Sprite2D sItem2 = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item2")), new Vector2(290, 240));
            GameManager.spriteProvider.Add("Item2", sItem2);
            Sprite2D sItem3 = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item3")), new Vector2(290, 300));
            GameManager.spriteProvider.Add("Item3", sItem3);
            Sprite2D sItem4 = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item4")), new Vector2(290, 360));
            GameManager.spriteProvider.Add("Item4", sItem4);
            Sprite2D sItem5 = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item5")), new Vector2(290, 420));
            GameManager.spriteProvider.Add("Item5", sItem5);
            Sprite2D sItem1_hover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item1_hover")), new Vector2(290, 180));
            GameManager.spriteProvider.Add("Item1_hover", sItem1_hover);
            Sprite2D sItem2_hover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item2_hover")), new Vector2(290, 240));
            GameManager.spriteProvider.Add("Item2_hover", sItem2_hover);
            Sprite2D sItem3_hover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item3_hover")), new Vector2(290, 300));
            GameManager.spriteProvider.Add("Item3_hover", sItem3_hover);
            Sprite2D sItem4_hover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item4_hover")), new Vector2(290, 360));
            GameManager.spriteProvider.Add("Item4_hover", sItem4_hover);
            Sprite2D sItem5_hover = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/item5_hover")), new Vector2(290, 420));
            GameManager.spriteProvider.Add("Item5_hover", sItem5_hover);
            Sprite2D sBackground = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/background")), Vector2.Zero);
            GameManager.spriteProvider.Add("Background", sBackground);
            Sprite2D sOption = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/OptionDialog")), new Vector2(135,97));
            GameManager.spriteProvider.Add("Option", sOption);
            Sprite2D sDe = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/De")), new Vector2(312, 305));
            GameManager.spriteProvider.Add("De", sDe);
            Sprite2D sDe_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/De_active")), new Vector2(312, 305));
            GameManager.spriteProvider.Add("De_active", sDe_active);
            Sprite2D sTrungbinh = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/TrungBinh")), new Vector2(368, 305));
            GameManager.spriteProvider.Add("TrungBinh", sTrungbinh);
            Sprite2D sTrungbinh_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/TrungBinh_active")), new Vector2(368, 305));
            GameManager.spriteProvider.Add("TrungBinh_active", sTrungbinh_active);
            Sprite2D sKho = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Kho")), new Vector2(551, 305));
            GameManager.spriteProvider.Add("Kho", sKho);
            Sprite2D sKho_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Kho_active")), new Vector2(551, 305));
            GameManager.spriteProvider.Add("Kho_active", sKho_active);
            Sprite2D sYeu = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Yeu")), new Vector2(338, 250));
            GameManager.spriteProvider.Add("Yeu", sYeu);
            Sprite2D sYeu_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Yeu_active")), new Vector2(338, 250));
            GameManager.spriteProvider.Add("Yeu_active", sYeu_active);
            Sprite2D sVua = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Vua")), new Vector2(416, 250));
            GameManager.spriteProvider.Add("Vua", sVua);
            Sprite2D sVua_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Vua_active")), new Vector2(416, 250));
            GameManager.spriteProvider.Add("Vua_active", sVua_active);
            Sprite2D sManh = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Manh")), new Vector2(498, 250));
            GameManager.spriteProvider.Add("Manh", sManh);
            Sprite2D sManh_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Manh_active")), new Vector2(498, 250));
            GameManager.spriteProvider.Add("Manh_active", sManh_active);
            Sprite2D sSelection = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Selection")), Vector2.Zero);
            GameManager.spriteProvider.Add("Selection", sSelection);
            Sprite2D sChiDan = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/ChiDan")), new Vector2(706,280));
            GameManager.spriteProvider.Add("ChiDan", sChiDan);

            Sprite2D sYeu_sound = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Yeu")), new Vector2(338, 200));
            GameManager.spriteProvider.Add("Yeu_sound", sYeu_sound);
            Sprite2D sYeu_sound_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Yeu_active")), new Vector2(338, 200));
            GameManager.spriteProvider.Add("Yeu_sound_active", sYeu_sound_active);
            Sprite2D sVua_sound = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Vua")), new Vector2(416, 200));
            GameManager.spriteProvider.Add("Vua_sound", sVua_sound);
            Sprite2D sVua_sound_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Vua_active")), new Vector2(416, 200));
            GameManager.spriteProvider.Add("Vua_sound_active", sVua_sound_active);
            Sprite2D sManh_sound = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Manh")), new Vector2(498, 200));
            GameManager.spriteProvider.Add("Manh_sound", sManh_sound);
            Sprite2D sManh_sound_active = new Sprite2D(new MyTexture(Content.Load<Texture2D>("Game/Manh_active")), new Vector2(498, 200));
            GameManager.spriteProvider.Add("Manh_sound_active", sManh_sound_active);


            //load character4
            List<MyTexture> list_up = new List<MyTexture>();
            List<MyTexture> list_down = new List<MyTexture>();
            List<MyTexture> list_right = new List<MyTexture>();
            List<MyTexture> list_left = new List<MyTexture>();

            for (int i = 1; i <= 6; i++)
            {
                list_up.Add(new MyTexture(Content.Load<Texture2D>("Character4/up" + i.ToString())));
                list_down.Add(new MyTexture(Content.Load<Texture2D>("Character4/down" + i.ToString())));
                list_right.Add(new MyTexture(Content.Load<Texture2D>("Character4/right" + i.ToString())));
                list_left.Add(new MyTexture(Content.Load<Texture2D>("Character4/left" + i.ToString())));
            }
            Sprite2D characterUp = new ObjectSprite2D(list_up, 5, 2, new Vector2(-16, -8),new Vector2(34, 54));
            Sprite2D characterDown = new ObjectSprite2D(list_down, 5, 2, new Vector2(16, 8),new Vector2(14, 53));
            Sprite2D characterLeft = new ObjectSprite2D(list_left, 5, 2, new Vector2(-16, 8),new Vector2(33, 53));
            Sprite2D characterRight = new ObjectSprite2D(list_right, 5, 2, new Vector2(16, -8),new Vector2(14, 54));

            GameManager.spriteProvider.Add("up", characterUp);
            GameManager.spriteProvider.Add("down", characterDown);
            GameManager.spriteProvider.Add("left", characterLeft);
            GameManager.spriteProvider.Add("right", characterRight);

            Sprite2D idle_up = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character4/idle_up")),new Vector2(16, 51));
            Sprite2D idle_down = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character4/idle_down")),new Vector2(16, 55));
            Sprite2D idle_left = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character4/idle_left")),new Vector2(16, 55));
            Sprite2D idle_right = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character4/idle_right")),new Vector2(16, 51));

            GameManager.spriteProvider.Add("idle_up", idle_up);
            GameManager.spriteProvider.Add("idle_down", idle_down);
            GameManager.spriteProvider.Add("idle_left", idle_left);
            GameManager.spriteProvider.Add("idle_right", idle_right);

            //load character1
            List<MyTexture> list_up1 = new List<MyTexture>();
            List<MyTexture> list_down1 = new List<MyTexture>();
            List<MyTexture> list_right1 = new List<MyTexture>();
            List<MyTexture> list_left1 = new List<MyTexture>();

            for (int i = 1; i <= 6; i++)
            {
                list_up1.Add(new MyTexture(Content.Load<Texture2D>("character1/character1_up_" + i.ToString())));
                list_down1.Add(new MyTexture(Content.Load<Texture2D>("character1/character1_down_" + i.ToString())));
                list_right1.Add(new MyTexture(Content.Load<Texture2D>("character1/character1_right_" + i.ToString())));
                list_left1.Add(new MyTexture(Content.Load<Texture2D>("character1/character1_left_" + i.ToString())));
            }
            Sprite2D characterUp1 = new ObjectSprite2D(list_up1, 5, 2, new Vector2(-16, -8), new Vector2(31, 59));
            Sprite2D characterDown1 = new ObjectSprite2D(list_down1, 5, 2, new Vector2(16, 8), new Vector2(17, 58));
            Sprite2D characterLeft1 = new ObjectSprite2D(list_left1, 5, 2, new Vector2(-16, 8), new Vector2(28, 58));
            Sprite2D characterRight1 = new ObjectSprite2D(list_right1, 5, 2, new Vector2(16, -8), new Vector2(10, 59));

            GameManager.spriteProvider.Add("character1_up", characterUp1);
            GameManager.spriteProvider.Add("character1_down", characterDown1);
            GameManager.spriteProvider.Add("character1_right", characterLeft1);
            GameManager.spriteProvider.Add("character1_left", characterRight1);

            Sprite2D idle_up1 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character1/character1_idle_up")), new Vector2(18, 51));
            Sprite2D idle_down1 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character1/character1_idle_down")), new Vector2(14, 52));
            Sprite2D idle_left1 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character1/character1_idle_left")), new Vector2(14, 55));
            Sprite2D idle_right1 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character1/character1_idle_right")), new Vector2(11, 51));

            GameManager.spriteProvider.Add("character1_idle_up", idle_up1);
            GameManager.spriteProvider.Add("character1_idle_down", idle_down1);
            GameManager.spriteProvider.Add("character1_idle_left", idle_left1);
            GameManager.spriteProvider.Add("character1_idle_right", idle_right1);

            //load character2
            List<MyTexture> list_up2 = new List<MyTexture>();
            List<MyTexture> list_down2 = new List<MyTexture>();
            List<MyTexture> list_right2 = new List<MyTexture>();
            List<MyTexture> list_left2 = new List<MyTexture>();

            for (int i = 1; i <= 6; i++)
            {
                list_up2.Add(new MyTexture(Content.Load<Texture2D>("character2/character2_up_" + i.ToString())));
                list_down2.Add(new MyTexture(Content.Load<Texture2D>("character2/character2_down_" + i.ToString())));
                list_right2.Add(new MyTexture(Content.Load<Texture2D>("character2/character2_right_" + i.ToString())));
                list_left2.Add(new MyTexture(Content.Load<Texture2D>("character2/character2_left_" + i.ToString())));
            }
            Sprite2D characterUp2 = new ObjectSprite2D(list_up2, 5, 2, new Vector2(-16, -8), new Vector2(33, 57));
            Sprite2D characterDown2 = new ObjectSprite2D(list_down2, 5, 2, new Vector2(16, 8), new Vector2(16, 51));
            Sprite2D characterLeft2 = new ObjectSprite2D(list_left2, 5, 2, new Vector2(-16, 8), new Vector2(28, 51));
            Sprite2D characterRight2 = new ObjectSprite2D(list_right2, 5, 2, new Vector2(16, -8), new Vector2(11, 55));

            GameManager.spriteProvider.Add("character2_up", characterUp2);
            GameManager.spriteProvider.Add("character2_down", characterDown2);
            GameManager.spriteProvider.Add("character2_right", characterLeft2);
            GameManager.spriteProvider.Add("character2_left", characterRight2);

            Sprite2D idle_up2 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character2/character2_idle_up")), new Vector2(16, 51));
            Sprite2D idle_down2 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character2/character2_idle_down")), new Vector2(16, 55));
            Sprite2D idle_left2 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character2/character2_idle_left")), new Vector2(16, 55));
            Sprite2D idle_right2 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character2/character2_idle_right")), new Vector2(16, 51));

            GameManager.spriteProvider.Add("character2_idle_up", idle_up2);
            GameManager.spriteProvider.Add("character2_idle_down", idle_down2);
            GameManager.spriteProvider.Add("character2_idle_left", idle_left2);
            GameManager.spriteProvider.Add("character2_idle_right", idle_right2);

            //load character3
            List<MyTexture> list_up3 = new List<MyTexture>();
            List<MyTexture> list_down3 = new List<MyTexture>();
            List<MyTexture> list_right3 = new List<MyTexture>();
            List<MyTexture> list_left3 = new List<MyTexture>();

            for (int i = 1; i <= 6; i++)
            {
                list_up3.Add(new MyTexture(Content.Load<Texture2D>("character3/character3_up_" + i.ToString())));
                list_down3.Add(new MyTexture(Content.Load<Texture2D>("character3/character3_down_" + i.ToString())));
                list_right3.Add(new MyTexture(Content.Load<Texture2D>("character3/character3_right_" + i.ToString())));
                list_left3.Add(new MyTexture(Content.Load<Texture2D>("character3/character3_left_" + i.ToString())));
            }
            Sprite2D characterUp3 = new ObjectSprite2D(list_up3, 5, 2, new Vector2(-16, -8), new Vector2(35, 54));
            Sprite2D characterDown3 = new ObjectSprite2D(list_down3, 5, 2, new Vector2(16, 8), new Vector2(17, 49));
            Sprite2D characterLeft3 = new ObjectSprite2D(list_left3, 5, 2, new Vector2(-16, 8), new Vector2(30, 50));
            Sprite2D characterRight3 = new ObjectSprite2D(list_right3, 5, 2, new Vector2(16, -8), new Vector2(15, 50));

            GameManager.spriteProvider.Add("character3_up", characterUp3);
            GameManager.spriteProvider.Add("character3_down", characterDown3);
            GameManager.spriteProvider.Add("character3_right", characterLeft3);
            GameManager.spriteProvider.Add("character3_left", characterRight3);

            Sprite2D idle_up3 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character3/character3_idle_up")), new Vector2(16, 48));
            Sprite2D idle_down3 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character3/character3_idle_down")), new Vector2(14, 49));
            Sprite2D idle_left3 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character3/character3_idle_left")), new Vector2(14, 50));
            Sprite2D idle_right3 = new ObjectSprite2D(new MyTexture(Content.Load<Texture2D>("character3/character3_idle_right")), new Vector2(17, 48));

            GameManager.spriteProvider.Add("character3_idle_up", idle_up3);
            GameManager.spriteProvider.Add("character3_idle_down", idle_down3);
            GameManager.spriteProvider.Add("character3_idle_left", idle_left3);
            GameManager.spriteProvider.Add("character3_idle_right", idle_right3);
        }
    }
}
