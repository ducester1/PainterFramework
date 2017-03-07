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
        private ThreeColorGameObject paintCan1, paintCan2, paintCan3;

        public GameWorld()
        {
            background = new SpriteGameObject("spr_background");
            cannonBarrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74, 404);
            cannonBarrel.Origin = new Vector2(34, 34);

            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");
            cannonColor.Position = new Vector2(58, 388);

            paintCan1 = new PaintCan(450,Color.Red);
            paintCan2 = new PaintCan(575, Color.Green);
            paintCan3 = new PaintCan(700, Color.Blue);

            this.Add(background);
            this.Add(cannonBarrel);
            this.Add(cannonColor);

            this.Add(paintCan1);
            this.Add(paintCan2);
            this.Add(paintCan3);
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

        public bool isOutsideWorld(Vector2 position)
        {
            return (position.X < 0 || position.X > Painter.Screen.X || position.Y < 0 || position.Y > Painter.Screen.Y);
        }
    }
}
