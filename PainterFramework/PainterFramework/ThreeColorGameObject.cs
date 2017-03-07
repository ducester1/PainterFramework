using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class ThreeColorGameObject : SpriteGameObject
    {
        protected SpriteSheet colorRed, colorGreen, colorBlue;
        protected Color color;

        public ThreeColorGameObject(string redAssetname, string greenAssetName, String blueAssetName)
            :base("")
            {
                colorRed = new SpriteSheet(redAssetname);
                colorGreen = new SpriteSheet(greenAssetName);
                colorBlue = new SpriteSheet(blueAssetName);

                Color = Color.Blue;
            }

        public virtual void Reset()
        {
            base.Reset();

            Color = Color.Blue;
        }

        public Color Color
        {
            get { return color; }
            set
            {
                if (value != Color.Red && value != Color.Green && value != Color.Blue)
                    return;
                color = value;
                if (color == Color.Red)
                    sprite = colorRed;
                else if (color == Color.Green)
                    sprite = colorGreen;
                else if (color == Color.Blue)
                    sprite = colorBlue;
            }
        }
    }
}
