using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PainterFramework
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class Painter : GameEnvironment
    {
        GameWorld gameWorld;
        SpriteGameObject background;

        public Painter()
        {
            gameWorld = new GameWorld();
            gameWorld.Add(background);
            gameStateManager.AddGameState("playingState", gameWorld);
            this.IsMouseVisible = true;
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameStateManager.SwitchTo("playingState");

            // TODO: use this.Content to load your game content here
        }
    }   
}
