using Microsoft.Xna.Framework;
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
            Visible = false;
            velocity = Vector2.Zero;
            Shooting = false;
            base.Reset();
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
    }
}
