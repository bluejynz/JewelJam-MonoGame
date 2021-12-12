using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class TextGameObject : GameObject
    {
        //variables
        protected SpriteFont font;
        protected Color color;
        protected Alignment alignment;

        //constructors
        public TextGameObject(string fontName, Color color, Alignment alignment = Alignment.Left)
        {
            font = ExtendedGame.ContentManager.Load<SpriteFont>(fontName);
            this.color = color;
            this.alignment = alignment;

            Text = "";
        }

        //props and enums
        public enum Alignment { Left, Center, Right }
        public string Text { get; set; }
        float OriginX { get {
                if (alignment == Alignment.Left)
                    return 0;
                if (alignment == Alignment.Right)
                    return font.MeasureString(Text).X;
                return font.MeasureString(Text).X / 2f;
            }
        }

        //monogame methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Visible)
                return;

            Vector2 origin = new Vector2(OriginX, 0);

            spriteBatch.DrawString(font, Text, GlobalPosition, color, 0f, origin, 1, SpriteEffects.None, 0);
        }

        //methods


    }
}
