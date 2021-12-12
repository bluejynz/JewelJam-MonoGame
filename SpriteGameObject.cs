using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JewelJam
{
    class SpriteGameObject : GameObject
    {
        //variables
        protected Texture2D sprite;
        protected Vector2 origin;

        //constructors
        public SpriteGameObject(string spriteName)
        {
            sprite = ExtendedGame.ContentManager.Load<Texture2D>(spriteName);
            origin = Vector2.Zero;
        }

        //props
        public int Width { get { return sprite.Width; } }
        public int Height { get { return sprite.Height; } }
        public Rectangle BoundingBox { get {
                Rectangle spriteBounds = sprite.Bounds;
                spriteBounds.Offset(GlobalPosition - origin);
                return spriteBounds;
            }
        }

        //monogame methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(sprite, GlobalPosition, null, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
            }
        }

        //methods
        public void SetOriginToCenter()
        {
            origin = new Vector2(Width, Height) / 2;
        }

    }
}
