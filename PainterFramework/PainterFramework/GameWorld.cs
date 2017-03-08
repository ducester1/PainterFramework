﻿using System;
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
        private Ball ball;
        private int maxLives = 5;
        private TextGameObject scoreText;

        public int lives{ get; set; }

        public int score { get; set; }

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

            ball = new Ball();

            scoreText = new TextGameObject("GameFont");

            this.Add(background);
            this.Add(cannonBarrel);
            this.Add(cannonColor);

            this.Add(paintCan1);
            this.Add(paintCan2);
            this.Add(paintCan3);

            this.Add(ball);

            this.Score = 0;
            this.lives = maxLives;

            this.Add(scoreText);
        }

        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                //if (scoreText != null)
                    scoreText.Text = "Score: " + value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (ball.CollidesWith(paintCan1))
            {
                paintCan1.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(paintCan2))
            {
                paintCan2.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(paintCan3))
            {
                paintCan3.Color = ball.Color;
                ball.Reset();
            }


            base.Update(gameTime);
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

            if (inputHelper.MouseLeftButtonPressed() && !ball.Shooting)
            {
                ball.Shoot(inputHelper, cannonColor, cannonBarrel);
            }
        }

        public bool isOutsideWorld(Vector2 position)
        {
            return position.X < 0 || position.X > Painter.Screen.X || position.Y > Painter.Screen.Y;
        }
    }
}
