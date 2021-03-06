﻿using Microsoft.Xna.Framework;
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
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity.Y <= 0f && GameEnvironment.Random.NextDouble() < 0.01)
            {
                Velocity = CalculateRandomVelocity();
                Color = CalculateRandomColor();
            }

            GameWorld gameWorld = GameWorld as GameWorld;
            if (gameWorld.isOutsideWorld(GlobalPosition))
            {
                if (Color == targetColor)
                {
                    gameWorld.Score += 10;
                    Painter.AssetManager.PlaySound("snd_collect_points");
                }
                else gameWorld.Lives -= 1;

                Reset();
            }
            //swaying 
            Angle = (float)Math.Sin(position.Y / 50.0f) * 0.1f;


            minVertVelocity += 0.001f;
            base.Update(gameTime);
        }

        public override void Reset()
        {
            base.Reset();
            position = new Vector2(this.horizontalPosOff, -BoundingBox.Height);
            velocity = Vector2.Zero;
        }

        public Vector2 CalculateRandomVelocity()
        {
            return new Vector2(0f,(float)GameEnvironment.Random.NextDouble()*30 + minVertVelocity);
        }

        public Color CalculateRandomColor()
        {
            int RandomColor = GameEnvironment.Random.Next(0, 3);

            if(RandomColor == 1) return Color.Red;
            else if(RandomColor == 2) return Color.Green;
            else  return Color.Blue;
            }
        }
    }