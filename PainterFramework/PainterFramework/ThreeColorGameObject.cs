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

                color = Color.Blue;
            }
    }
}
