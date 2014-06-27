using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class NormalZombie : Zombie
    {
        public NormalZombie()
        {
            this.idZombie_die = "NormalZombie_Die";
            this.idZombie_eating = "NormalZombie_Eating";
            this.idZombie_running = "NormalZombie_Running";
            this.model = new ZombieModel(this);
            this.damageEating = 10;//gan damage eating cho zombie
        }
    }
}
