using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JewelJam
{
    class GameObject
    {
        //variables
        protected Vector2 velocity;

        //constructors
        public GameObject()
        {
            LocalPosition = Vector2.Zero;
            velocity = Vector2.Zero;
            Visible = true;
        }

        //props
        public GameObject Parent { get; set; }
        public Vector2 LocalPosition { get; set; }
        public Vector2 GlobalPosition { get {
                if (Parent == null)
                    return LocalPosition;
                return LocalPosition + Parent.GlobalPosition;
            }
        }
        public bool Visible { get; set; }

        //monogame methods
        public virtual void Update(GameTime gameTime) {
            LocalPosition += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

        public virtual void Reset()
        {
            velocity = Vector2.Zero;
        }

        //methods
        public virtual void HandleInput(InputHelper inputHelper) { }
    }
}
