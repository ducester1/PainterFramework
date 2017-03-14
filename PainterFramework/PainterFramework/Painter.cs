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
        GameOver gameover;
        

        public Painter()
        {
            Content.RootDirectory = "Content";
                       
            this.IsMouseVisible = true;
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            base.LoadContent();
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameStateManager.AddGameState("playingState", new GameWorld());
            gameStateManager.AddGameState("GameOverGameState", new GameOver());
            gameStateManager.SwitchTo("playingState");
            //gameStateManager.SwitchTo("GameOverGameState");



            AssetManager.PlayMusic("snd_music");

            // TODO: use this.Content to load your game content here
        }
    }   
}
