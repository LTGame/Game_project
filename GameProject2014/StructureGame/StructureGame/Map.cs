using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public abstract class Map: VisibleGameEntity
    {
        float[] rows = new float[4];//4 hang so y cho 4 hang dung de ve
        Vector2[,] cells = new Vector2[9, 5]; //9x5 vector2 quy dinh vi tri dat plant, trong tam cua tung o 

        MainEntity[,] matrix = new MainEntity[9, 5]; //luu tru doi tuong nao da dat vao day
        Sprite2D background = null;

        public override void Update(GameTime gameTime)
        {
            if (background != null)
                background.update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (background != null)
                background.draw(spriteBatch);
        }

        //i hang nao
       public float getRow(int i)
       {
           if(i>=0 && i< rows.GetLength(0))
            return rows[i];
           return -1;
       }

        //o nao
       public Vector2 getCell(int i, int j)
       {
           if (i >= 0 && i < cells.GetLength(0) && j >= 0 && j < cells.GetLength(1))
               return cells[i, j];
           return Vector2.Zero;
       }

       public bool putEntityonMap(MainEntity entity, int i, int j)
       {
           if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
               if (matrix[i, j] == null)
               {
                   matrix[i, j] = entity;
                   return true;
               }
           return false;
       }

       public bool removeEntityonMap(MainEntity entity)
       {
           for (int i = 0; i < matrix.GetLength(0);i++)
               for (int j = 0; j < matrix.GetLength(1); j++)
               {
                   if (matrix[i, j] == entity)
                   {
                       matrix[i, j] = null;
                       return true;
                   }
               }
           return false;
       }
    }
}
