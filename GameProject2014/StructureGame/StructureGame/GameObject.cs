using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class GameObject : MainEntity
    {
        public GameObject(ObjectSprite2D sprite, Index[] indexs, float depth)
        {
            this.currentSprite = sprite;
            this.SpaceMap = indexs;
            this.depth = 0.005f;
        }

        public GameObject(ObjectSprite2D sprite, float depth)
        {
            this.currentSprite = sprite;
            Index[] indexs = new Index[1];
            indexs[0] = new Index(0, 0);
            this.SpaceMap = indexs;
            this.depth = 0.005f;
        }

        public virtual GameObject Clone()
        {
            ObjectSprite2D s = (ObjectSprite2D)this.currentSprite.Clone();
            GameObject obj = new GameObject( s, this.SpaceMap,depth);
            s.Entity = obj;
            return obj;
        }


    }
}
