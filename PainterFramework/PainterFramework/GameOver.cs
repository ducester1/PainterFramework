using Microsoft.Xna.Framework;

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
    }
}