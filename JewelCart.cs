using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        GlitterField glitters;

        //constructors
        public JewelCart(Vector2 startPosition) : base("spr_jewelcart")
        {
            LocalPosition = startPosition;
            startX = startPosition.X;
            glitters = new GlitterField(sprite, 40, new Rectangle(275, 470, 430, 85));
            glitters.Parent = this;
        }

        //props

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            glitters.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            glitters.Draw(gameTime, spriteBatch);
        }

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

        public void PushForward()
        {
            LocalPosition = new Vector2(MathHelper.Max(LocalPosition.X + pushDistance, startX), LocalPosition.Y);
        }

    }
}
