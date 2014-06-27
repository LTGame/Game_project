using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class TreasureDialog : Dialog
    {
        Treasure treasure;
        Sprite2D book, sTreasure, manual;

        void ClickExit()
        {
            GameManager.currentScreen.List_enity.Remove(treasure);
            if (treasure.Question != null)
                GameManager.currentScreen.Dialog = new QuestionDialog(treasure.Question,treasure.LoaiRuong);
            else
                GameManager.currentScreen.Dialog = null;
        }

        public TreasureDialog(Treasure treasure)
        {
            this.treasure = treasure;
            this.currentSprite = GameManager.spriteProvider.getSprite("TreasureDialog");
            this.currentSprite.Entity = this;
            this.depth = 0.1f;

            if (treasure.LoaiRuong == 0)
            {
                sTreasure = GameManager.spriteProvider.getSprite("Gold");
                GameManager.playingCharacter.NGold++;
            }
            else if (treasure.LoaiRuong == 1)
            {
                sTreasure = GameManager.spriteProvider.getSprite("Silver");
                GameManager.playingCharacter.NSilver++;
            }
            else if (treasure.LoaiRuong == 2)
            {
                sTreasure = GameManager.spriteProvider.getSprite("Titan");
                GameManager.playingCharacter.NSilver++;
            }
            else if (treasure.LoaiRuong == 3)
            {
                sTreasure = GameManager.spriteProvider.getSprite("Diamond");
                GameManager.playingCharacter.NDiamond++;
            }
            else
            {
                sTreasure = GameManager.spriteProvider.getSprite("NonTreasure");
            }
            if (treasure.Magic == 1)
            {
                book = GameManager.spriteProvider.getSprite("VenusBook");
                GameManager.playingCharacter.NVenusBook++;
            }
            else if (treasure.Magic == 2)
            {
                book = GameManager.spriteProvider.getSprite("MarsBook");
                GameManager.playingCharacter.NMarsBook++;
            }
            else if (treasure.Magic == 3)
            {
                book = GameManager.spriteProvider.getSprite("MecuryBook");
                GameManager.playingCharacter.NMecuryBook++;
            }
            else if (treasure.Magic == 3)
            {
                book = GameManager.spriteProvider.getSprite("SaturnBook");
                GameManager.playingCharacter.NSaturnBook++;
            }
            else
                book = GameManager.spriteProvider.getSprite("NonBook");

            if (treasure.Question == null)
                manual = GameManager.spriteProvider.getSprite("NonManual");
            else
                manual = GameManager.spriteProvider.getSprite("Manual");

            Sprite2D spriteExit = GameManager.spriteProvider.getSprite("button_dialog");
            MenuItem exit = new MenuItem(Vector2.Zero, ClickExit, spriteExit, spriteExit, 0.01f);
            list_entity_dialog.Add(exit);
            handler = new ContextEventHandler(list_entity_dialog);
        }

        public override void Update(GameTime gameTime)
        {
            book.update(gameTime);
            sTreasure.update(gameTime);
            manual.update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            book.draw(spriteBatch, 0.09f);
            sTreasure.draw(spriteBatch, 0.09f);
            manual.draw(spriteBatch, 0.09f);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
