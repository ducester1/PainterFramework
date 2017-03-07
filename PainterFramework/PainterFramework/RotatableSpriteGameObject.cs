using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PainterFramework
{
    class RotatableSpriteGameObject : SpriteGameObject
    {
        protected float angle;
        public RotatableSpriteGameObject(String assetname, int layer = 0, string id = "", int sheetIndex = 0)
            :base (assetname, layer, id, sheetIndex)
            {
                
            }

        public float Angle { get { return angle; } set { angle = value; } }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible != true || sprite == null) return;
            spriteBatch.Draw(sprite.Sprite, this.GlobalPosition, null, Color.White, angle, this.origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
