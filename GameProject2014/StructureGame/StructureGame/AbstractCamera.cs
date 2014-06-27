using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public abstract class AbstractCamera : InvisibleGameEntity
    {
        Matrix _World = Matrix.Identity;

        public Matrix World
        {
            get { return _World; }
            set { _World = value; }
        }
        Matrix _View = Matrix.Identity;

        public Matrix View
        {
            get { return _View; }
            set { _View = value; }
        }
        Matrix _Project = Matrix.Identity;

        public Matrix Project
        {
            get { return _Project; }
            set { _Project = value; }
        }

        public Matrix WVPMatrix
        {
            get
            {
                return _World * _View * _Project;
            }
        }

        public Matrix InverWVPMaTrix
        {
            get
            {
                return Matrix.Invert(WVPMatrix);
            }
        }

        protected float xScale, yScale;

        public float YScale
        {
            get { return yScale; }
            set { yScale = value; }
        }

        public float XScale
        {
            get { return xScale; }
            set { xScale = value; }
        }
        protected float xTrans, yTrans;

        public float YTrans
        {
            get { return yTrans; }
            set { yTrans = value; }
        }

        public float XTrans
        {
            get { return xTrans; }
            set { xTrans = value; }
        }
        protected float zRot;

        public float ZRot
        {
            get { return zRot; }
            set { zRot = value; }
        }

        public abstract Vector2 World2View(Vector2 worldPos);

        public abstract Vector2 View2World(Vector2 viewPos);
    }
}
