using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class PaintCan : ThreeColorGameObject
    {
        protected Color targetColor;
        protected float minVertVelocity;
        protected float horizontalPosOff;

        public PaintCan(float horizontalPosOff, Color targetColor)
            :base("spr_can_red", "spr_can_green", "spr_can_blue")
        {
            this.horizontalPosOff = horizontalPosOff;
            this.targetColor = targetColor;

            minVertVelocity = 30;
        }
    }
}
