using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class ExtendedGame : Game
    {
        //variables
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected InputHelper inputHelper;

        protected static GameObjectList gameWorld;

        protected Point worldSize;
        protected Point windowSize;

        protected Matrix spriteScale;

        //constructors
        protected ExtendedGame()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            inputHelper = new InputHelper();
            Random = new Random();

            windowSize = new Point(1024, 768);
            worldSize = new Point(1024, 768);
        }

        //props
        public static Random Random { get; private set; }
        public static ContentManager ContentManager { get; private set; }
        public bool Fullscreen { get { return graphics.IsFullScreen; } protected set { ApplyResolutionSettings(value); } }

        //monogame methods
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager = Content;
            Fullscreen = false;
            gameWorld = new GameObjectList();
        }

        protected override void Update(GameTime gameTime)
        {
            HandleInput();

            gameWorld.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);

            gameWorld.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        //methods
        protected virtual void HandleInput()
        {
            inputHelper.Update();

            if (inputHelper.KeyPressed(Keys.Escape))
                Exit();

            if (inputHelper.KeyPressed(Keys.F5))
                Fullscreen = !Fullscreen;

            gameWorld.HandleInput(inputHelper);
        }

        void ApplyResolutionSettings(bool fullscreen)
        {
            Point screenSize;
            if (fullscreen)
                screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            else
                screenSize = windowSize;

            graphics.IsFullScreen = fullscreen;
            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;
            graphics.ApplyChanges();

            GraphicsDevice.Viewport = CalculateViewport(screenSize);
            spriteScale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / worldSize.X, (float)GraphicsDevice.Viewport.Height / worldSize.Y, 1);
        }

        Viewport CalculateViewport(Point windowSize)
        {
            Viewport viewport = new Viewport();
            float gameAspectRatio = (float)worldSize.X / worldSize.Y;
            float windowAspectRatio = (float)windowSize.X / windowSize.Y;

            if (windowAspectRatio > gameAspectRatio)
            {
                viewport.Width = (int)(windowSize.Y * gameAspectRatio);
                viewport.Height = windowSize.Y;
            }
            else
            {
                viewport.Width = windowSize.X;
                viewport.Height = (int)(windowSize.X / gameAspectRatio);
            }
            viewport.X = (windowSize.X - viewport.Width) / 2;
            viewport.Y = (windowSize.Y - viewport.Height) / 2;

            return viewport;
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
            float screenToWorldScale = worldSize.X / (float)GraphicsDevice.Viewport.Width;

            return (screenPosition - viewportTopLeft) * screenToWorldScale;
        }

    }
}
