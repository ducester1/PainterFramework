using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class GameOver : GameObjectList
    {
        TextGameObject text;
        public GameOver()
            {
            text = new TextGameObject("GameFont");
            this.Add(text);

            text.Text = "Game over dude! Game over!";
            text.Position = new Vector2(200, Painter.Screen.Y / 2);
            
            }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
            {
                Painter.GameStateManager.SwitchTo("playingState");
                Painter.GameStateManager.CurrentGameState.Reset();
            }
        }
    }
}