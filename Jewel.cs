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

        //constructors
        public Jewel() : base("spr_jewels")
        {
            ColorType = ExtendedGame.Random.Next(3);
            ShapeType = ExtendedGame.Random.Next(3);
            NumberType = ExtendedGame.Random.Next(3);
            int index = 9 * ColorType + 3 * ShapeType + NumberType;
            spriteRectangle = new Rectangle(index * sprite.Height, 0, sprite.Height, sprite.Height);
        }

        //props
        public int ColorType { get; private set; }
        public int ShapeType { get; private set; }
        public int NumberType { get; private set; }

        //monogame methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GlobalPosition, spriteRectangle, Color.White);
        }

        //methods
    }
}
