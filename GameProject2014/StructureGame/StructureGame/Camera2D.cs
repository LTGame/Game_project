using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class Camera2D : AbstractCamera
    {
        public Camera2D(float xscale, float yscale, float zrot, float xtrans, float ytrans)
        {
            this.xScale = xscale;
            this.yScale = yscale;
            this.xTrans = xtrans;
            this.yTrans = ytrans;
            this.zRot = zrot;
        }

        public Camera2D()
        {
            this.xScale = 1;
            this.yScale = 1;
            this.xTrans = 0;
            this.yTrans = 0;
            this.zRot = 0;
        }

        public override void Update(GameTime gameTime)
        {
            View = Matrix.CreateScale(xScale, yScale, 1)
                    * Matrix.CreateRotationZ(zRot)
                    * Matrix.CreateTranslation(xTrans, yTrans, 0);
        }

        public override Vector2 World2View(Vector2 worldPos)
        {
            return Vector2.Transform(worldPos, WVPMatrix);
        }

        public override Vector2 View2World(Vector2 viewPos)
        {
            return Vector2.Transform(viewPos, InverWVPMaTrix);
        }
    }
}
