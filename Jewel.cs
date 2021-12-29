using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class Jewel : SpriteGameObject
    {
        //variables
        Rectangle spriteRectangle;
        GlitterField glitters;

        //constructors
        public Jewel() : base("spr_jewels")
        {
            ColorType = ExtendedGame.Random.Next(3);
            ShapeType = ExtendedGame.Random.Next(3);
            NumberType = ExtendedGame.Random.Next(3);
            int index = 9 * ColorType + 3 * ShapeType + NumberType;
            spriteRectangle = new Rectangle(index * sprite.Height, 0, sprite.Height, sprite.Height);
            TargetPosition = Vector2.Zero;
            glitters = new GlitterField(sprite, 2, spriteRectangle);
            glitters.LocalPosition = -spriteRectangle.Location.ToVector2();
            glitters.Parent = this;
        }

        //props
        public int ColorType { get; private set; }
        public int ShapeType { get; private set; }
        public int NumberType { get; private set; }
        public Vector2 TargetPosition { get; set; }

        //monogame methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GlobalPosition, spriteRectangle, Color.White);
            glitters.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 diff = TargetPosition - LocalPosition;
            velocity = diff * 8;

            base.Update(gameTime);
            glitters.Update(gameTime);
        }

        //methods
    }
}
