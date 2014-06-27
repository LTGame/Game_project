using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class PeaShooter : Plant
    {
        public PeaShooter()
        {
            this.idPlant_attack = "PeaShooter_attack";
            this.idPlant_sleep = "PeaShooter_sleep";
            this.idPlant_stand = "PeaShooter_stand";
            this.model = new PlantModel(this);
            this.hp = 100;//gan mau vo
        }

        public override void Update(GameTime gameTime)
        {
            //tan cong va da hoan thanh hanh dong chuan bi ban dan
            if (currentState == PlantState.Attack && model.finishState())
            {
                //tao dan di
                //them no danh sach visibleentity cua gamescreen
            }
            //chet ngat no roi
            else if (hp <=0)
            {
                //xoa no khoi danh sach visibleEntity
                //xoa khoi map
            }
            base.Update(gameTime);
        }
    }
}
