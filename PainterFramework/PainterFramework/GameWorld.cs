using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background;

        public GameWorld()
        {
            background = new SpriteGameObject("spr_background");

            this.Add(background);
        }
    }
}
