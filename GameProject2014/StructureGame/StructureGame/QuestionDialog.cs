using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class QuestionDialog : Dialog
    {
        Question question;
        StringBuilder builder;
        int n;
        bool DaTraLoi;
        int stick = 0;
        int loaiRuong;


        public void ClickA()
        {
            DaTraLoi = true;
            if (question.Answer.Equals("A"))
            {
                TraLoiDung();
            }
            else
                GameManager.playingCharacter.Point--;
        }

        public void ClickB()
        {
            DaTraLoi = true;
            if (question.Answer.Equals("B"))
            {
                TraLoiDung();
            }
            else
                GameManager.playingCharacter.Point--;
        }
        public void ClickC()
        {
            DaTraLoi = true;
            if (question.Answer.Equals("C"))
            {
                TraLoiDung();
            }
            else
                GameManager.playingCharacter.Point--;
        }

        public void ClickD()
        {
            DaTraLoi = true;
            if (question.Answer.Equals("D"))
            {
                TraLoiDung();
            }
            else
                GameManager.playingCharacter.Point--;
        }

        private void TraLoiDung()
        {
            //0:vang, 1:bac, 2:titan, 3: kim cuong
            if (loaiRuong == 0 || loaiRuong == 3)
            {
                Random rd = new Random();
                GameManager.playingCharacter.Point += rd.Next(5) + 5;
            }
            else
                GameManager.playingCharacter.Point += 5;
        }


        MenuItem ItemA,ItemB,ItemC,ItemD;
        public QuestionDialog(Question question, int loairuong)
        {
            this.question = question;
           this.currentSprite = GameManager.spriteProvider.getSprite("QuestionDialog");
           this.currentSprite.Entity = this;
           this.depth = 0.0001f;
            
            Sprite2D redRound = GameManager.spriteProvider.getSprite("RedRound");
            Sprite2D blackRound = GameManager.spriteProvider.getSprite("BlackRound");
            builder = MultilineText(question.Statement, 20,ref n);

            Sprite2D rA = redRound.Clone();
            Sprite2D bA = blackRound.Clone();
            rA.Vector = new Vector2(133, 148 + 30);
            bA.Vector = new Vector2(133, 148 + 30);

            Sprite2D rB = redRound.Clone();
            Sprite2D bB = blackRound.Clone();
            rB.Vector = new Vector2(133, 148 + 30*2);
            bB.Vector = new Vector2(133, 148 + 30*2);

            Sprite2D rC = redRound.Clone();
            Sprite2D bC = blackRound.Clone();
            rC.Vector = new Vector2(133, 148 + 30 * 3);
            bC.Vector = new Vector2(133, 148 + 30 * 3);

            Sprite2D rD = redRound.Clone();
            Sprite2D bD = blackRound.Clone();
            rD.Vector = new Vector2(133, 148 + 30 * 4);
            bD.Vector = new Vector2(133, 148 + 30 * 4);

            ItemA = new MenuItem(Vector2.Zero, ClickA, bA, rA, 0.00001f);
            ItemB = new MenuItem(Vector2.Zero, ClickB, bB, rB, 0.00001f);
            ItemC = new MenuItem(Vector2.Zero, ClickC, bC, rC, 0.00001f);
            ItemD = new MenuItem(Vector2.Zero, ClickD, bD, rD, 0.00001f);

            list_entity_dialog.Add(ItemA);
            list_entity_dialog.Add(ItemB);
            list_entity_dialog.Add(ItemC);
            list_entity_dialog.Add(ItemD);

            handler = new ContextEventHandler(list_entity_dialog);

            DaTraLoi = false;
            loaiRuong = loairuong;
        }

        public override void Update(GameTime gameTime)
        {
            if (DaTraLoi)
            {
                stick++;
                if (stick > 100)
                    GameManager.currentScreen.Dialog = null;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameManager.font, builder, new Vector2(133, 106), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);
            if (DaTraLoi && question.Answer.Equals("A"))
                spriteBatch.DrawString(GameManager.font, question.A, new Vector2(153, 106 + 30 * (n + 1)), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);
            else
                spriteBatch.DrawString(GameManager.font, question.A, new Vector2(153, 106 + 30 * (n + 1)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);

            if (DaTraLoi && question.Answer.Equals("B"))
                spriteBatch.DrawString(GameManager.font, question.B, new Vector2(153, 106 + 30 * (n + 2)), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);
            else
                spriteBatch.DrawString(GameManager.font, question.B, new Vector2(153, 106 + 30 * (n + 2)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);

            if (DaTraLoi && question.Answer.Equals("C"))
                spriteBatch.DrawString(GameManager.font, question.C, new Vector2(153, 106 + 30 * (n + 3)), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);
            else
                spriteBatch.DrawString(GameManager.font, question.C, new Vector2(153, 106 + 30 * (n + 3)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);

            if (DaTraLoi && question.Answer.Equals("D"))
                spriteBatch.DrawString(GameManager.font, question.D, new Vector2(153, 106 + 30 * (n + 4)), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);
            else
                spriteBatch.DrawString(GameManager.font, question.D, new Vector2(153, 106 + 30 * (n + 4)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.00001f);

            base.Draw(gameTime, spriteBatch);

        }

        private StringBuilder MultilineText(String s, int length,ref int n)
        {
            StringBuilder builder = new StringBuilder();
            n = s.Length / length;
            for (int i = 0; i < n; i++)
            {
                builder.Append(s.Substring(i * length, length));
                builder.AppendLine();
            }
            builder.Append(s.Substring(n * length, s.Length - n * length));
            n++;
            return builder;
        }
    }
}
