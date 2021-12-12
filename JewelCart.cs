using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class JewelCart : SpriteGameObject
    {
        //variables and consts
        const float speed = 10;
        const float pushDistance = 100;
        float startX;

        //constructors
        public JewelCart(Vector2 startPosition) : base("spr_jewelcart")
        {
            LocalPosition = startPosition;
            startX = startPosition.X;
        }

        //props

        //monogame methods

        //methods
        public override void Reset()
        {
            velocity.X = speed;
            LocalPosition = new Vector2(startX, LocalPosition.Y);
        }

        public void PushBack()
        {
            LocalPosition = new Vector2(MathHelper.Max(LocalPosition.X - pushDistance, startX), LocalPosition.Y);
        }

    }
}
