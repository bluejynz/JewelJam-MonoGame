using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class ScoreGameObject : TextGameObject
    {
        //constructors
        public ScoreGameObject() : base("JewelJamFont", Color.White, Alignment.Right)
        {
        }

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            Text = JewelJam.GameWorld.Score.ToString();
        }
    }
}
