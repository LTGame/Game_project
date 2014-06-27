using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StructureGame
{
    public class Character : MainEntity
    {
        int nMecuryBook = 0;
        bool finish = false;
        bool lostTurn = false;
        int timer = 0;

        public bool Finish
        {
            get { return finish; }
            set { finish = value; }
        }

        public int NMecuryBook
        {
            get { return nMecuryBook; }
            set { nMecuryBook = value; }
        }
        int nMarsBook = 0;

        public int NMarsBook
        {
            get { return nMarsBook; }
            set { nMarsBook = value; }
        }
        int nSaturnBook = 0;

        public int NSaturnBook
        {
            get { return nSaturnBook; }
            set { nSaturnBook = value; }
        }
        int nVenusBook = 0;

        public int NVenusBook
        {
            get { return nVenusBook; }
            set { nVenusBook = value; }
        }

        int nGold = 0;

        public int NGold
        {
            get { return nGold; }
            set { nGold = value; }
        }
        int nTitan = 0;

        public int NTitan
        {
            get { return nTitan; }
            set { nTitan = value; }
        }
        int nSilver = 0;

        public int NSilver
        {
            get { return nSilver; }
            set { nSilver = value; }
        }
        int nDiamond = 0;

        public int NDiamond
        {
            get { return nDiamond; }
            set { nDiamond = value; }
        }

        int point = 0;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        int nTurn;

        public int NTurn
        {
            get { return nTurn; }
            set { nTurn = value; }
        }

        Index goal;

        public Index Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        Index iUp = new Index(-1, 0);
        Index iDown = new Index(1, 0);
        Index iLeft = new Index(0, 1);
        Index iRight = new Index(0, -1); // vector cong don vao

        
        KeyboardHelper keyUp, keyDown, keyRight, keyLeft;
        bool runningLeft, runningRight, runningUp, runningDown;
        ObjectSprite2D spriteUp, spriteDown, spriteRight, spriteLeft;
        ObjectSprite2D spriteIdle_Up, spriteIdle_Down, spriteIdle_Right, spriteIdle_Left;

        public Character(Index indexMap,Index goal, int maxTurn,KeyboardHelper keyUp, ObjectSprite2D spriteIdle_Up, ObjectSprite2D spriteUp, KeyboardHelper keyDown, ObjectSprite2D spriteIdle_Down, ObjectSprite2D spriteDown, KeyboardHelper keyRight, ObjectSprite2D spriteIdle_Right, ObjectSprite2D spriteRight, KeyboardHelper keyLeft, ObjectSprite2D spriteIdle_Left, ObjectSprite2D spriteLeft, float depth)
        {
            this.indexMap = indexMap;
            this.goal = goal;
            this.nTurn = 2 * maxTurn;

            this.depth = 0.005f;

            this.keyUp = keyUp;
            this.keyDown = keyDown;
            this.keyRight = keyRight;
            this.keyLeft = keyLeft;

            this.spriteUp = spriteUp;
            this.spriteRight = spriteRight;
            this.spriteLeft = spriteLeft;
            this.spriteDown = spriteDown;

            this.spriteIdle_Up = spriteIdle_Up;
            this.spriteIdle_Down = spriteIdle_Down;
            this.spriteIdle_Left = spriteIdle_Left;
            this.spriteIdle_Right = spriteIdle_Right;

            this.spriteUp.Entity = this;
            this.spriteDown.Entity = this;
            this.spriteLeft.Entity = this;
            this.spriteRight.Entity = this;
            this.spriteIdle_Up.Entity = this;
            this.spriteIdle_Down.Entity = this;
            this.spriteIdle_Left.Entity = this;
            this.spriteIdle_Right.Entity = this;

            this.spaceMap = new Index[1];
            spaceMap[0] = new Index(0, 0);

            //xac dinh idle nao se gan cho current sprite
            /*
            int X = GameManager.currentScreen.Map.Matrix.GetLength(0);
            int Y = GameManager.currentScreen.Map.Matrix.GetLength(1);
            if (this.indexMap.X < X / 2 && this.indexMap.Y < Y / 2) this.currentSprite = this.spriteIdle_Down;
            else if (this.indexMap.X > X / 2 && this.indexMap.Y < Y / 2) this.currentSprite = this.spriteIdle_Up;
            else if (this.indexMap.X < X / 2 && this.indexMap.Y > Y / 2) this.currentSprite = this.spriteIdle_Right;
            else */
            this.currentSprite = this.spriteIdle_Left;
        }

        public override void Update(GameTime gameTime)
        {
            if (lostTurn)
            {
                timer++;
                if (timer > 50)
                {
                    GameManager.endTurn = true;
                    timer = 0;
                    lostTurn = false;
                }
                return;
               }

            keyUp.Update(gameTime);
            keyDown.Update(gameTime);
            keyRight.Update(gameTime);
            keyLeft.Update(gameTime);

            if(runningDown)
            {
                if (currentSprite.Finish)
                {
                    Index newIndex = new Index(indexMap.X + iDown.X, indexMap.Y + iDown.Y);
                    GameManager.currentScreen.Map.ChangeIndexObject(this, newIndex);
                    currentSprite = spriteIdle_Down;
                    runningDown = false;
                    GameManager.endTurn = true;
                }

            }
            else if (runningUp)
            {
                if (currentSprite.Finish)
                {
                    Index newIndex = new Index(indexMap.X + iUp.X, indexMap.Y + iUp.Y);
                    GameManager.currentScreen.Map.ChangeIndexObject(this, newIndex);
                    currentSprite = spriteIdle_Up;
                    runningUp = false;
                    GameManager.endTurn = true;
                }

            }
            else if (runningLeft)
            {
                if (currentSprite.Finish)
                {
                    Index newIndex = new Index(indexMap.X + iLeft.X, indexMap.Y + iLeft.Y);
                    GameManager.currentScreen.Map.ChangeIndexObject(this, newIndex);
                    currentSprite = spriteIdle_Left;
                    runningLeft = false;
                    GameManager.endTurn = true;
                }

            }
            else if (runningRight)
            {
                if (currentSprite.Finish)
                {
                    Index newIndex = new Index(indexMap.X + iRight.X, indexMap.Y + iRight.Y);
                    GameManager.currentScreen.Map.ChangeIndexObject(this, newIndex);
                    currentSprite = spriteIdle_Right;
                    runningRight = false;
                    GameManager.endTurn = true;
                }

            }
            else // idle
            {
                if (keyUp.HasKeyUp())
                {
                    nTurn--;
                    Index tmp = new Index(indexMap.X+iUp.X,indexMap.Y+iUp.Y);
                    if (GameManager.currentScreen.Map.canRunInto(tmp))
                    {
                        currentSprite = spriteUp;
                        currentSprite.Run();
                        runningUp = true;
                    }
                    else
                    {
                        GameManager.coin.Play(GameManager.volumeSound, 0, 0);
                        lostTurn = true;
                    }
                }
                else if (keyDown.HasKeyDown())
                {
                    nTurn--;
                    Index tmp = new Index(indexMap.X+iDown.X,indexMap.Y+iDown.Y);
                    if (GameManager.currentScreen.Map.canRunInto(tmp))
                    {
                        currentSprite = spriteDown;
                        currentSprite.Run();
                        runningDown = true;
                    }
                    else
                    {
                        GameManager.coin.Play(GameManager.volumeSound, 0, 0);
                        lostTurn = true;
                    }
                }
                else if (keyRight.HasKeyDown())
                {
                    nTurn--;
                    Index tmp = new Index(indexMap.X+iRight.X,indexMap.Y+iRight.Y);
                    if (GameManager.currentScreen.Map.canRunInto(tmp))
                    {
                        currentSprite = spriteRight;
                        currentSprite.Run();
                        runningRight = true;
                    }
                    else
                    {
                        GameManager.coin.Play(GameManager.volumeSound, 0, 0);
                        lostTurn = true;
                    }
                }
                else if (keyLeft.HasKeyDown())
                {
                    nTurn--;
                    Index tmp = new Index(indexMap.X+iLeft.X,indexMap.Y+iLeft.Y);
                    if (GameManager.currentScreen.Map.canRunInto(tmp))
                    {
                        currentSprite = spriteLeft;
                        currentSprite.Run();
                        runningLeft = true;
                    }
                    else
                    {
                        GameManager.coin.Play(GameManager.volumeSound, 0, 0);
                        lostTurn = true;
                    }
                }


            }
            //kiem tra da thang chua
            if (indexMap.X == goal.X && indexMap.Y == goal.Y)
            {
                finish = true;
                point += 15;
                point += TinhDiem(NTitan);
                point += TinhDiem(NGold);
                point += TinhDiem(NSilver);
                point += TinhDiem(NDiamond);
                point += TinhDiem(NVenusBook);
                point += TinhDiem(NSaturnBook);
                point += TinhDiem(NMarsBook);
                point += TinhDiem(NMecuryBook);
            }
            if (nTurn <= 0)
            {
                //thua no roi
                finish = true;
                point += TinhDiem(NTitan);
                point += TinhDiem(NGold);
                point += TinhDiem(NSilver);
                point += TinhDiem(NDiamond);
                point += TinhDiem(NVenusBook);
                point += TinhDiem(NSaturnBook);
                point += TinhDiem(NMarsBook);
                point += TinhDiem(NMecuryBook);
            }

            base.Update(gameTime);
        }

        private int TinhDiem(int n)
        {
            int point = 0;
            if (n > 4)
                {
                    point += (n / 4)*20;
                    n %= 4;
                }
                if (n == 3)
                    point += 10;
                if(n == 2)
                    point += 5;
           return point;
        }

        public Sprite2D getImage()
        {
            return this.spriteIdle_Down;
        }
    }
}
