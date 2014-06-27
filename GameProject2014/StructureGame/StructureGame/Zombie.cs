using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public abstract class Zombie : MainEntity
    {
        public enum ZombieState { Eating, Running, Die};

        public float damageEating;
        public ZombieState currentState = ZombieState.Running;
        public string idZombie_running;
        public string idZombie_eating;
        public string idZombie_die;
        public int row; //hang ma zombie dang dung
        public ZombieModel model;
    }
}
