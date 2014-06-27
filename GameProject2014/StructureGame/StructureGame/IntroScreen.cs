using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StructureGame
{
    public class IntroScreen : Screen
    {
        void button1()
        {
            GameManager.currentScreen = new GameScreen();
        }

        void button2()
        {
            Character[] characters = new Character[4];
            
            ObjectSprite2D characterUp4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("up");
            ObjectSprite2D characterDown4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("down");
            ObjectSprite2D characterLeft4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("left");
            ObjectSprite2D characterRight4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("right");

            ObjectSprite2D idleUp4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_up");
            ObjectSprite2D idleDown4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_down");
            ObjectSprite2D idleLeft4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_left");
            ObjectSprite2D idleRight4 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_right");


            ObjectSprite2D characterUp2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_up");
            ObjectSprite2D characterDown2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_down");
            ObjectSprite2D characterLeft2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_right");
            ObjectSprite2D characterRight2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_left");

            ObjectSprite2D idleUp2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_idle_up");
            ObjectSprite2D idleDown2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_idle_down");
            ObjectSprite2D idleLeft2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_idle_left");
            ObjectSprite2D idleRight2 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character2_idle_right");

            ObjectSprite2D characterUp = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_up");
            ObjectSprite2D characterDown = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_down");
            ObjectSprite2D characterLeft = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_right");
            ObjectSprite2D characterRight = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_left");

            ObjectSprite2D idleUp = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_idle_up");
            ObjectSprite2D idleDown = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_idle_down");
            ObjectSprite2D idleLeft = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_idle_left");
            ObjectSprite2D idleRight = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character1_idle_right");

            ObjectSprite2D characterUp3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_up");
            ObjectSprite2D characterDown3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_down");
            ObjectSprite2D characterLeft3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_right");
            ObjectSprite2D characterRight3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_left");

            ObjectSprite2D idleUp3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_idle_up");
            ObjectSprite2D idleDown3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_idle_down");
            ObjectSprite2D idleLeft3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_idle_left");
            ObjectSprite2D idleRight3 = (ObjectSprite2D)GameManager.spriteProvider.getSprite("character3_idle_right");

            int n = GameManager.nRows;
            int m = GameManager.nCols;

            int maxTurn = (n + m);//cong thuc quy uoc ve tong so turn
            Random rd = new Random();

            Index[] goals = new Index[4];
            for (int i = 0; i < 4; i++)
            {
                int x = rd.Next(n);
                int y = rd.Next(m);
                if ((x == 0 && y == 0) || (x == n - 1 && y == m - 1)
                    && (x == n - 1 && y == 0) && (x == 0 && y == m - 1))
                    i--;
                else
                {
                    bool Corol = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == goals[j].X && y == goals[j].Y)
                        {
                            Corol = true;
                            break;
                        }
                    }
                    if (!Corol)
                    {
                        goals[i] = new Index(x, y);
                    }
                    else
                        i--;
                }

            }

            characters[0] = new Character(new Index(0, 0), goals[0], maxTurn,
                                                    new KeyboardHelper(Keys.W), idleUp, characterUp,
                                                    new KeyboardHelper(Keys.S), idleDown, characterDown,
                                                    new KeyboardHelper(Keys.D), idleRight, characterRight,
                                                    new KeyboardHelper(Keys.A), idleLeft, characterLeft, 0.05f);

            characters[1] = new Character(new Index(0, m - 1), goals[1], maxTurn,
                                                    new KeyboardHelper(Keys.W), idleUp2, characterUp2,
                                                    new KeyboardHelper(Keys.S), idleDown2, characterDown2,
                                                    new KeyboardHelper(Keys.D), idleRight2, characterRight2,
                                                    new KeyboardHelper(Keys.A), idleLeft2, characterLeft2, 0.05f);

            characters[2] = new Character(new Index(n - 1, 0), goals[2], maxTurn,
                                                    new KeyboardHelper(Keys.W), idleUp3, characterUp3,
                                                    new KeyboardHelper(Keys.S), idleDown3, characterDown3,
                                                    new KeyboardHelper(Keys.D), idleRight3, characterRight3,
                                                    new KeyboardHelper(Keys.A), idleLeft3, characterLeft3, 0.05f);

            characters[3] = new Character(new Index(n - 1, m - 1), goals[3], maxTurn,
                                                    new KeyboardHelper(Keys.W), idleUp4, characterUp4,
                                                    new KeyboardHelper(Keys.S), idleDown4, characterDown4,
                                                    new KeyboardHelper(Keys.D), idleRight4, characterRight4,
                                                    new KeyboardHelper(Keys.A), idleLeft4, characterLeft4, 0.05f);
            GameManager.currentScreen = new MultiGameScreen(characters, goals);
        }

        void button4()
        {
            GameManager.currentScreen.Dialog = new OptionDialog();
        }

        void button5()
        {
            GameManager.ExitGame = true;
        }

        public IntroScreen()
        {
            this.background = GameManager.spriteProvider.getSprite("Background");

            //load menuitems
            this.List_enity.Add(new MenuItem(Vector2.Zero, button1, GameManager.spriteProvider.getSprite("Item1").Clone(), GameManager.spriteProvider.getSprite("Item1_hover").Clone(), 0.05f));
            this.List_enity.Add(new MenuItem(Vector2.Zero, button2, GameManager.spriteProvider.getSprite("Item2").Clone(), GameManager.spriteProvider.getSprite("Item2_hover").Clone(), 0.05f));
            this.List_enity.Add(new MenuItem(Vector2.Zero, null, GameManager.spriteProvider.getSprite("Item3").Clone(), GameManager.spriteProvider.getSprite("Item3_hover").Clone(), 0.05f));
            this.List_enity.Add(new MenuItem(Vector2.Zero, button4, GameManager.spriteProvider.getSprite("Item4").Clone(), GameManager.spriteProvider.getSprite("Item4_hover").Clone(), 0.05f));
            this.List_enity.Add(new MenuItem(Vector2.Zero, button5, GameManager.spriteProvider.getSprite("Item5").Clone(), GameManager.spriteProvider.getSprite("Item5_hover").Clone(), 0.05f));


            this.eventHandler = new EventHandler(this.List_enity);
        }
    }

}
