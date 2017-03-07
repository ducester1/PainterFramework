using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background;
        private SpriteGameObject cannonBarrel;
        private ThreeColorGameObject cannonColor;

        public GameWorld()
        {
            background = new SpriteGameObject("spr_background");
            cannonBarrel = new SpriteGameObject("spr_cannon-barrel");
            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");

            this.Add(background);
            this.Add(cannonBarrel);
            this.Add(cannonColor);
        }
    }
}
