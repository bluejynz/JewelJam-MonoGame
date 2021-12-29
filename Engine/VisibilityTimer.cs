using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class VisibilityTimer : GameObject
    {
        //vars
        GameObject target;
        float timeLeft;

        //constructors
        public VisibilityTimer(GameObject target)
        {
            timeLeft = 0;
            this.target = target;
        }

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            if (timeLeft <= 0)
                return;

            timeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeLeft <= 0)
                target.Visible = false;
        }

        //methods
        public void StartVisible(float seconds)
        {
            timeLeft = seconds;
            target.Visible = true;
        }

    }
}
