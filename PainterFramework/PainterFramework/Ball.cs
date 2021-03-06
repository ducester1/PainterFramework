﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PainterFramework
{
    class Ball : ThreeColorGameObject
    {
        public bool Shooting { get; set; }
        public Ball()
            :base("spr_ball_red","spr_ball_green","spr_ball_blue")
        {

        }

        public override void Reset()
        {
            base.Reset();
            Visible = false;
            velocity = Vector2.Zero;
            Shooting = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shooting == true)
            {
                velocity.X *= .99f;
                velocity.Y += 6;
            }

            GameWorld gameWorld = GameWorld as GameWorld;
            if (gameWorld.isOutsideWorld(GlobalPosition)) Reset();
            base.Update(gameTime);
        }

        public void Shoot(InputHelper inputHelper, ThreeColorGameObject cannonColor, RotatableSpriteGameObject cannonBarrel)
        {
            Shooting = true;
            Color = cannonColor.Color;

            velocity = (inputHelper.MousePosition - cannonColor.GlobalPosition);
            visible = true;

            float opp = (float)Math.Sin(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            float adj = (float)Math.Cos(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            position = cannonColor.Position + new Vector2(adj, opp) + new Vector2(3, 3);

            Painter.AssetManager.PlaySound("snd_shoot_paint");
        }
    }
}
