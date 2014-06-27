using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StructureGame
{
    public class GameScreen : Screen
    {
        Sprite2D frame;
        Sprite2D sObjectInfo;
        Sprite2D sGameover;
        Sprite2D chiDan;

        KeyboardHelper exit;

        Vector2 vector = new Vector2(76, 372);

        Character character1;

        bool gameOver = false;

        public GameScreen()
        {
            exit = new KeyboardHelper(Keys.Escape);

            this.camera = new Camera2D();
            this.interaction = new Interaction();

            Tile[] array_tile = new Tile[1];
            Sprite2D st_1 = GameManager.spriteProvider.getSprite("glass");
            array_tile[0] = new Tile(st_1, 1,null,0.09f);

            int[,] matrix = new int[GameManager.nRows, GameManager.nCols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    matrix[i, j] = 1;
                }
            }

            map = new IsolateMap(array_tile, matrix, 32, new Vector2(32, 16),0.9f);

            frame = GameManager.spriteProvider.getSprite("Frame");
            sObjectInfo= GameManager.spriteProvider.getSprite("ObjectInfor");
            sGameover = GameManager.spriteProvider.getSprite("GameOver");
            chiDan = GameManager.spriteProvider.getSprite("ChiDan");

            ObjectSprite2D characterUp = (ObjectSprite2D)GameManager.spriteProvider.getSprite("up");
            ObjectSprite2D characterDown = (ObjectSprite2D)GameManager.spriteProvider.getSprite("down");
            ObjectSprite2D characterLeft = (ObjectSprite2D)GameManager.spriteProvider.getSprite("left");
            ObjectSprite2D characterRight = (ObjectSprite2D)GameManager.spriteProvider.getSprite("right");

            ObjectSprite2D idleUp = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_up");
            ObjectSprite2D idleDown = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_down");
            ObjectSprite2D idleLeft = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_left");
            ObjectSprite2D idleRight = (ObjectSprite2D)GameManager.spriteProvider.getSprite("idle_right");

            int maxTurn = (Map.Matrix.GetLength(0) + Map.Matrix.GetLength(1));//cong thuc quy uoc ve tong so turn
            Random rd = new Random();
            Index goal = new Index(rd.Next(Map.Matrix.GetLength(0)), rd.Next(Map.Matrix.GetLength(1)));

            character1 = new Character(new Index(0, 0),goal, maxTurn,
                                                    new KeyboardHelper(Keys.W), idleUp, characterUp,
                                                    new KeyboardHelper(Keys.S), idleDown, characterDown,
                                                    new KeyboardHelper(Keys.D), idleRight, characterRight,
                                                    new KeyboardHelper(Keys.A), idleLeft, characterLeft,0.05f);
            Index[] goals = new Index[1];
            goals[0] = goal;
            map.GoalIndexs = goals;
            map.SetObject(character1);
            List_enity.Add(character1);

            MapGenerator.LocateObject(this.List_enity, this.map, GameManager.nObject);
            MapGenerator.LocateTreasure(this.List_enity, this.map, GameManager.nTreasure);

            eventHandler = new EventHandler(List_enity);

            GameManager.playingCharacter = character1;
        }

        public override void Update(GameTime gameTime)
        {
            exit.Update(gameTime);
            if (exit.HasKeyDown())
            {
                GameManager.currentScreen = new IntroScreen();
                return;
            }
            if (gameOver)
            {
                return;
            }
            if (character1 != null && character1.Finish)
            {
                gameOver = true;
            }
            
            base.Update(gameTime);
        }

        public override void Draw2(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (gameOver)
            {
                sGameover.draw(spriteBatch, 0.001f);
            }
            chiDan.draw(spriteBatch, 0.05f);
            frame.draw(spriteBatch,0.05f);

            if (character1 != null)
            {
                Sprite2D image = character1.getImage();
                image.draw(spriteBatch, Color.White, image.Vector + (new Vector2(-32, -370)), 1f, 0.04f);
                sObjectInfo.draw(spriteBatch, Color.White, new Vector2(-80, -366), 1f, 0.04f);
                spriteBatch.DrawString(GameManager.fontInfo, "T: "+character1.NTurn.ToString(), new Vector2(20, 425), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, "P: " + character1.Point.ToString(), new Vector2(20, 445), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                               
                spriteBatch.DrawString(GameManager.fontInfo, character1.NSaturnBook.ToString(), new Vector2(114, 370), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NVenusBook.ToString(), new Vector2(170, 370), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NMarsBook.ToString(), new Vector2(114, 395), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NMecuryBook.ToString(), new Vector2(170, 395), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NDiamond.ToString(), new Vector2(114, 424), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NGold.ToString(), new Vector2(170, 424), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NSilver.ToString(), new Vector2(114, 448), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, character1.NTitan.ToString(), new Vector2(170, 448), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
            }
            base.Draw2(gameTime, spriteBatch);
        }
    }
}
