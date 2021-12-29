using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class GameObjectList : GameObject
    {
        //variables
        List<GameObject> children;

        //constructors
        public GameObjectList()
        {
            children = new List<GameObject>();
        }

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in children)
                child.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject child in children)
                child.Draw(gameTime, spriteBatch);
        }

        //methods
        public override void Reset()
        {
            foreach (GameObject child in children)
                child.Reset();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            foreach (GameObject child in children)
                child.HandleInput(inputHelper);
        }

        public void AddChild(GameObject child)
        {
            child.Parent = this;
            children.Add(child);
        }
    }
}
