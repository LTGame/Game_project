using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class MapGenerator
    {
        static public void LocateObject(List<VisibleGameEntity> mainEntitys, Map map, int n)
        {
            List<String> keys = GameManager.objectProvider.getKeys();
            //tinh so object tren map theo dai,rong

            int x, y, pObj;
            int nKeys = keys.Count, nCols = map.Matrix.GetLength(1), nRows = map.Matrix.GetLength(0);
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                pObj = rd.Next(nKeys);
                x = rd.Next(nRows);
                y = rd.Next(nCols);
                GameObject obj = GameManager.objectProvider.getObject(keys[pObj]).Clone();
                obj.IndexMap = new Index(x, y);
                if (map.CanSetObject(obj))
                {
                    map.SetObject(obj);
                    mainEntitys.Add(obj);
                }
                else
                    i--; //lap lai buoc nay
            }
        }

        static public void LocateTreasure(List<VisibleGameEntity> mainEntitys, Map map, int n)
        {
            Random rd = new Random();
            int x, y;
            int nCols = map.Matrix.GetLength(1), nRows = map.Matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                Treasure treasure = null;
                int rGiaithuong = rd.Next(5);
                //random 5 truong hop co the cua ruong bau
                if (rGiaithuong == 0) // 1 ruong 0 magic 0 question
                {
                    int ruong = rd.Next(4);
                    treasure = new Treasure(ruong, -1, null);
                }
                else if (rGiaithuong == 1) // 0 ruong 1 magic 0 question
                {
                    int magic = rd.Next(4);
                    treasure = new Treasure(-1, magic , null);
                }
                else if (rGiaithuong == 2) // 1 ruong 1 magic 0 question
                {
                    int magic = rd.Next(4);
                    int ruong = rd.Next(4);
                    treasure = new Treasure(ruong, magic, null);
                }
                else if (rGiaithuong == 3) // 1 ruong 0 magic 1 question
                {
                    Question question = GameManager.questionProvider.getQuestion();
                    int ruong = rd.Next(4);
                    treasure = new Treasure(ruong, -1, question);
                }
                else if (rGiaithuong == 4) // 1 ruong 1 magic 1 question
                {
                    Question question = GameManager.questionProvider.getQuestion();
                    int magic = rd.Next(4);
                    int ruong = rd.Next(4);
                    treasure = new Treasure(ruong, magic, question);
                }

                treasure.SpaceMap = new Index[1];
                treasure.SpaceMap[0] = new Index(0, 0);
                do{
                x = rd.Next(nRows);
                y = rd.Next(nCols);
                treasure.IndexMap = new Index(x,y);
                }
                while (!map.CanSetObject(treasure));

                map.SetObject(treasure);
                mainEntitys.Add(treasure);
            }

        }
    }
}
