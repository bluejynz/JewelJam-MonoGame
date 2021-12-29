using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class JewelJamGameWorld : GameObjectList
    {
        //variables and consts
        const int GridWidth = 5;
        const int GridHeight = 10;
        const int CellSize = 85;

        JewelJam game;

        VisibilityTimer timerDouble, timerTriple;
        JewelCart jewelCart;
        SpriteGameObject titleScreen, gameOverScreen, helpScreen, helpButton;
        GameState currentState;

        //constructors
        public JewelJamGameWorld(JewelJam game)
        {
            this.game = game;

            SpriteGameObject background = new SpriteGameObject("spr_background");
            Size = new Point(background.Width, background.Height);
            AddChild(background);

            SpriteGameObject scoreFrame = new SpriteGameObject("spr_scoreframe");
            scoreFrame.LocalPosition = new Vector2(20, 20);
            AddChild(scoreFrame);

            ScoreGameObject scoreObject = new ScoreGameObject();
            scoreObject.LocalPosition = new Vector2(270, 30);
            AddChild(scoreObject);

            GameObjectList playingField = new GameObjectList();
            playingField.LocalPosition = new Vector2(85, 150);
            AddChild(playingField);

            JewelGrid grid = new JewelGrid(GridWidth, GridHeight, CellSize);
            playingField.AddChild(grid);

            playingField.AddChild(new RowSelector(grid));

            jewelCart = new JewelCart(new Vector2(410, 230));
            AddChild(jewelCart);

            helpButton = new SpriteGameObject("spr_button_help");
            helpButton.LocalPosition = new Vector2(1270, 20);
            AddChild(helpButton);

            timerDouble = AddComboImageWithTimer("spr_double");
            timerTriple = AddComboImageWithTimer("spr_triple");

            titleScreen = AddOverlay("spr_title");
            gameOverScreen = AddOverlay("spr_gameover");
            helpScreen = AddOverlay("spr_frame_help");

            GoToState(GameState.TitleScreen);

            ExtendedGame.AssetManager.PlaySong("snd_music", true);
        }

        //props and enums
        enum GameState { TitleScreen, Playing, HelpScreen, GameOver }
        public Point Size { get; private set; }
        public int Score { get; private set; }

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            if(currentState == GameState.Playing)
            {
                base.Update(gameTime);
                if (jewelCart.GlobalPosition.X > Size.X - 230)
                {
                    GoToState(GameState.GameOver);
                    ExtendedGame.AssetManager.PlaySoundEffect("snd_gameover");
                }
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.M))
                ExtendedGame.AssetManager.StopSong();

            if (currentState == GameState.Playing)
            {
                base.HandleInput(inputHelper);
                if (inputHelper.MouseLeftButtonPressed() && helpButton.BoundingBox.Contains(game.ScreenToWorld(inputHelper.MousePosition)))
                {
                    GoToState(GameState.HelpScreen);
                }
            }
            else if (currentState == GameState.TitleScreen || currentState == GameState.GameOver)
            {
                if (inputHelper.KeyPressed(Keys.Space))
                {
                    Reset();
                    GoToState(GameState.Playing);
                }
            }
            else if (currentState == GameState.HelpScreen)
            {
                if(inputHelper.KeyPressed(Keys.Space))
                    GoToState(GameState.Playing);
            }
        }

        //methods
        public override void Reset()
        {
            base.Reset();
            Score = 0;
        }

        public void AddScore(int points)
        {
            Score += points;
            jewelCart.PushBack();
        }

        public void ReduceScore(int points)
        {
            Score -= points;
        }

        public SpriteGameObject AddOverlay(string sprName)
        {
            SpriteGameObject obj = new SpriteGameObject(sprName);
            obj.SetOriginToCenter();
            obj.LocalPosition = new Vector2(Size.X, Size.Y) / 2;
            AddChild(obj);
            return obj;
        }

        void GoToState(GameState newState)
        {
            currentState = newState;
            titleScreen.Visible = currentState == GameState.TitleScreen;
            helpScreen.Visible = currentState == GameState.HelpScreen;
            gameOverScreen.Visible = currentState == GameState.GameOver;
        }

        VisibilityTimer AddComboImageWithTimer(string spriteName)
        {
            SpriteGameObject image = new SpriteGameObject(spriteName);
            image.Visible = false;
            image.LocalPosition = new Vector2(800, 400);
            AddChild(image);

            VisibilityTimer timer = new VisibilityTimer(image);
            AddChild(timer);

            return timer;
        }

        public void DoubleComboScored()
        {
            timerDouble.StartVisible(3);
        }

        public void TripleComboScored()
        {
            timerTriple.StartVisible(3);
        }

        public void WrongCombination()
        {
            jewelCart.PushForward();
        }

    }
}
