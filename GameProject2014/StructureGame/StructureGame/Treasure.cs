using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class Treasure : MainEntity
    {
        int loaiRuong; //0:vang, 1:bac, 2:titan, 3: kim cuong

        public int LoaiRuong
        {
            get { return loaiRuong; }
            set { loaiRuong = value; }
        }


        int magic; //0: hoa, 1: moc, 2:tho, 3:kim

        public int Magic
        {
            get { return magic; }
            set { magic = value; }
        }
        Question question;

        public Question Question
        {
            get { return question; }
            set { question = value; }
        }

        public Treasure(int LoaiRuong, int Magic, Question question)
        {
            this.LoaiRuong = LoaiRuong;
            this.Magic = Magic;
            this.question = question;
            this.currentSprite = GameManager.spriteProvider.getSprite("Treasure").Clone();
            this.currentSprite.Entity = this;
            this.depth = 0.005f;
        }

        public void OpenTreasure()
        {
            GameManager.currentScreen.Dialog = new TreasureDialog(this);
        }

        public override bool canRunInto()
        {
            return true;
        }
    }
}
