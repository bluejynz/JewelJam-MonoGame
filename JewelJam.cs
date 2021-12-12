using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace JewelJam
{
    class JewelJam : ExtendedGame
    {
        //variables

        //constructors
        public JewelJam()
        {
            IsMouseVisible = true;
        }

        //props
        public static JewelJamGameWorld GameWorld { get { return (JewelJamGameWorld)gameWorld; } }

        //methods
        protected override void LoadContent()
        {
            base.LoadContent();

            gameWorld = new JewelJamGameWorld(this);
            worldSize = GameWorld.Size;

            Fullscreen = false;
        }
    }
}
