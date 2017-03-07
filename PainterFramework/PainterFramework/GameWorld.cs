using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace PainterFramework
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background;
        private RotatableSpriteGameObject cannonBarrel;
        private ThreeColorGameObject cannonColor;

        public GameWorld()
        {
            background = new SpriteGameObject("spr_background");
            cannonBarrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74, 404);
            cannonBarrel.Origin = new Vector2(34, 34);

            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");
            cannonColor.Position = new Vector2(58, 388);

            this.Add(background);
            this.Add(cannonBarrel);
            this.Add(cannonColor);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.R)) cannonColor.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G)) cannonColor.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B)) cannonColor.Color = Color.Blue;

            double opposite = inputHelper.MousePosition.Y - cannonBarrel.GlobalPosition.Y;
            double adjacent = inputHelper.MousePosition.X - cannonBarrel.GlobalPosition.X;
            cannonBarrel.Angle = (float)Math.Atan2(opposite, adjacent);
        }
    }
}
