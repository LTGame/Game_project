using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StructureGame
{
    public class MultiGameScreen: Screen
    {
        
        Sprite2D frame;
        Sprite2D sObjectInfo;
        Sprite2D chiDan;

        bool firstUpdate = true;
        Vector2 vector = new Vector2(76, 372);
        Sprite2D selection;

        Character[] characters;
        int iChar;
        KeyboardHelper exit;
        public MultiGameScreen(Character[] characters, Index[] goals)
        {
            exit = new KeyboardHelper(Keys.Escape);

            this.characters = characters;
            this.camera = new Camera2D();
            this.interaction = new Interaction();

            Tile[] array_tile = new Tile[1];
            Sprite2D st_1 = GameManager.spriteProvider.getSprite("glass");
            array_tile[0] = new Tile(st_1, 1,null,0.09f);

            int[,] matrix = new int[GameManager.nRows, GameManager.nCols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 1;
                }
            }

            map = new IsolateMap(array_tile, matrix, 32, new Vector2(32, 16),0.9f);

            frame = GameManager.spriteProvider.getSprite("Frame");
            sObjectInfo= GameManager.spriteProvider.getSprite("ObjectInfor");
            selection = GameManager.spriteProvider.getSprite("Selection");
            chiDan = GameManager.spriteProvider.getSprite("ChiDan");

            map.SetObject(characters[0]);
            List_enity.Add(characters[0]);
            map.SetObject(characters[1]);
            List_enity.Add(characters[1]);
            map.SetObject(characters[2]);
            List_enity.Add(characters[2]);
            map.SetObject(characters[3]);
            List_enity.Add(characters[3]);

            map.GoalIndexs = goals;

            MapGenerator.LocateObject(this.List_enity, this.map, GameManager.nObject);
            MapGenerator.LocateTreasure(this.List_enity, this.map, GameManager.nTreasure);

            eventHandler = new EventHandler(List_enity);

            GameManager.playingCharacter = characters[0];
            iChar = 0;

        }

        public override void Update(GameTime gameTime)
        {
            exit.Update(gameTime);
            if (exit.HasKeyDown())
            {
                GameManager.currentScreen = new IntroScreen();
                return;
            }
            if (GameManager.endTurn)
            {
                iChar++;
                iChar %= 4;
                if (characters[iChar].Finish == false)
                {
                    GameManager.playingCharacter = characters[iChar];
                    GameManager.endTurn = false;
                }
                else
                    return;
            }
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
                if (map != null)
                    map.Update(gameTime);
                if (camera != null)
                    camera.Update(gameTime);
            }
            foreach (VisibleGameEntity entity in list_enity)
            {
                if (entity is Character && entity != GameManager.playingCharacter && firstUpdate == false)
                    continue;
                if (entity is Character && ((Character)entity).Finish)
                    continue;
                entity.Update(gameTime);
            }
            firstUpdate = false;
            if (interaction != null)
                interaction.Update(gameTime);
            if (background != null)
                background.update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (VisibleGameEntity entity in list_enity)
            {
                if (entity is Character && ((Character)entity).Finish)
                    continue;
                entity.Draw(gameTime, spriteBatch);
            }

            if (map != null)
                map.Draw(gameTime, spriteBatch);

            if (background != null)
                background.draw(spriteBatch, 0.9f);
        }

        public override void Draw2(GameTime gameTime, SpriteBatch spriteBatch)
        {
            frame.draw(spriteBatch,0.05f);
            chiDan.draw(spriteBatch, 0.05f);

            if (characters[0] != null)
            {
                Sprite2D image = characters[0].getImage();
                image.draw(spriteBatch, Color.White, image.Vector + new Vector2(-32, -370), 1f, 0.04f);

                if (characters[0] == GameManager.playingCharacter)
                 selection.draw(spriteBatch, Color.White, new Vector2(-10, -350), 1f, 0.03f);

                sObjectInfo.draw(spriteBatch, Color.White, new Vector2(-80, -366), 1f, 0.04f);
                spriteBatch.DrawString(GameManager.fontInfo, "T: " + characters[0].NTurn.ToString(), new Vector2(20, 425), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, "P: " + characters[0].Point.ToString(), new Vector2(20, 445), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);

                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NSaturnBook.ToString(), new Vector2(114, 370), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NVenusBook.ToString(), new Vector2(170, 370), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NMarsBook.ToString(), new Vector2(114, 395), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NMecuryBook.ToString(), new Vector2(170, 395), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NDiamond.ToString(), new Vector2(114, 424), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NGold.ToString(), new Vector2(170, 424), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NSilver.ToString(), new Vector2(114, 448), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[0].NTitan.ToString(), new Vector2(170, 448), Color.OrangeRed, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
            }
            if (characters[1] != null)
            {
                Sprite2D image = characters[1].getImage();
                image.draw(spriteBatch, Color.White,image.Vector + new Vector2(-232, -370), 1f, 0.04f);

                if (characters[1] == GameManager.playingCharacter)
                selection.draw(spriteBatch, Color.White, new Vector2(-210, -350), 1f, 0.03f);

                sObjectInfo.draw(spriteBatch, Color.White, new Vector2(-280, -366), 1f, 0.04f);
                spriteBatch.DrawString(GameManager.fontInfo, "T: " + characters[1].NTurn.ToString(), new Vector2(220, 425), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, "P: " + characters[1].Point.ToString(), new Vector2(220, 445), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);

                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NSaturnBook.ToString(), new Vector2(314, 370), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NVenusBook.ToString(), new Vector2(370, 370), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NMarsBook.ToString(), new Vector2(314, 395), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NMecuryBook.ToString(), new Vector2(370, 395), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NDiamond.ToString(), new Vector2(314, 424), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NGold.ToString(), new Vector2(370, 424), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NSilver.ToString(), new Vector2(314, 448), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[1].NTitan.ToString(), new Vector2(370, 448), Color.Blue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
            }

            if (characters[2]!= null)
            {
                Sprite2D image = characters[2].getImage();
                image.draw(spriteBatch, Color.White,image.Vector + new Vector2(-432, -370), 1f, 0.04f);

                if (characters[2] == GameManager.playingCharacter)
                selection.draw(spriteBatch, Color.White, new Vector2(-410, -350), 1f, 0.03f);

                sObjectInfo.draw(spriteBatch, Color.White, new Vector2(-480, -366), 1f, 0.04f);
                spriteBatch.DrawString(GameManager.fontInfo, "T: " + characters[2].NTurn.ToString(), new Vector2(420, 425), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, "P: " + characters[2].Point.ToString(), new Vector2(420, 445), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);

                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NSaturnBook.ToString(), new Vector2(514, 370), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NVenusBook.ToString(), new Vector2(570, 370), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NMarsBook.ToString(), new Vector2(514, 395), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NMecuryBook.ToString(), new Vector2(570, 395), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NDiamond.ToString(), new Vector2(514, 424), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NGold.ToString(), new Vector2(570, 424), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NSilver.ToString(), new Vector2(514, 448), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[2].NTitan.ToString(), new Vector2(570, 448), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
            }

            if (characters[3] != null)
            {
                Sprite2D image = characters[3].getImage();
                image.draw(spriteBatch, Color.White,image.Vector + new Vector2(-632, -370), 1f, 0.04f);

                if (characters[3] == GameManager.playingCharacter)
                selection.draw(spriteBatch, Color.White, new Vector2(-610, -350), 1f, 0.03f);

                sObjectInfo.draw(spriteBatch, Color.White, new Vector2(-680, -366), 1f, 0.04f);
                spriteBatch.DrawString(GameManager.fontInfo, "T: " + characters[3].NTurn.ToString(), new Vector2(620, 425), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, "P: " + characters[3].Point.ToString(), new Vector2(620, 445), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);

                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NSaturnBook.ToString(), new Vector2(714, 370), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NVenusBook.ToString(), new Vector2(770, 370), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NMarsBook.ToString(), new Vector2(714, 395), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NMecuryBook.ToString(), new Vector2(770, 395), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NDiamond.ToString(), new Vector2(714, 424), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NGold.ToString(), new Vector2(770, 424), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NSilver.ToString(), new Vector2(714, 448), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
                spriteBatch.DrawString(GameManager.fontInfo, characters[3].NTitan.ToString(), new Vector2(770, 448), Color.Purple, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.03f);
            }
            base.Draw2(gameTime, spriteBatch);
        }
    }
}
