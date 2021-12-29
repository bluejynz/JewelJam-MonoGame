using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class JewelGrid : GameObject
    {
        //variables
        Jewel[,] grid;
        int cellSize;

        //constructors
        public JewelGrid(int width, int height, int cellSize)
        {
            Width = width;
            Height = height;
            this.cellSize = cellSize;
            Reset();
        }

        //props
        public int Height { get; private set; }
        public int Width { get; private set; }

        //monogame methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Jewel jewel in grid)
                jewel.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Jewel j in grid)
                j.Update(gameTime);
        }

        //methods
        public override void Reset()
        {
            grid = new Jewel[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    AddJewel(x, y, y);
                }
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.R))
            {
                if (JewelJam.GameWorld.Score < 100)
                    ExtendedGame.AssetManager.PlaySoundEffect("snd_error");
                else
                {
                    JewelJam.GameWorld.ReduceScore(100);
                    ExtendedGame.AssetManager.PlaySoundEffect("snd_single");
                    foreach (Jewel j in grid)
                        j.RandomizeAllTypes();
                }
            }

            if (!inputHelper.KeyPressed(Keys.Space))
                return;

            int combo = 0;
            int extraScore = 45;
            int mid = Width / 2;
            for(int y = 0; y < Height - 2; y++)
            {
                if (IsValidCombination(grid[mid, y], grid[mid, y + 1], grid[mid, y + 2]))
                {
                    combo++;
                    JewelJam.GameWorld.AddScore(extraScore);
                    extraScore *= 3;

                    RemoveJewel(mid, y, -1);
                    RemoveJewel(mid, y + 1, -2);
                    RemoveJewel(mid, y + 2, -3);
                    y += 2;
                }
            }
            if (combo == 0)
            {
                ExtendedGame.AssetManager.PlaySoundEffect("snd_error");
                JewelJam.GameWorld.WrongCombination();
            }
            else if (combo == 1)
            {
                ExtendedGame.AssetManager.PlaySoundEffect("snd_single");
            }
            else if (combo == 2)
            {
                JewelJam.GameWorld.DoubleComboScored();
                ExtendedGame.AssetManager.PlaySoundEffect("snd_double");
            }
            else if (combo == 3)
            {
                JewelJam.GameWorld.TripleComboScored();
                ExtendedGame.AssetManager.PlaySoundEffect("snd_triple");
            }
        }

        void RemoveJewel(int x, int y, int yStartForNewJewel)
        {
            for (int row = y; row > 0; row--)
            {
                grid[x, row] = grid[x, row - 1];
                grid[x, row].TargetPosition = GetCellPosition(x, row);
            }

            AddJewel(x, 0, yStartForNewJewel);
        }

        void AddJewel(int x, int yTarget, int yStart)
        {
            grid[x, yTarget] = new Jewel();
            grid[x, yTarget].Parent = this;
            grid[x, yTarget].LocalPosition = GetCellPosition(x, yStart);
            grid[x, yTarget].TargetPosition = GetCellPosition(x, yTarget);
        }

        public Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * cellSize, y * cellSize);
        }

        public void ShiftRowLeft(int selectedRow)
        {
            Jewel first = grid[0, selectedRow];
            for(int x = 0; x < Width - 1; x++)
            {
                grid[x, selectedRow] = grid[x + 1, selectedRow];
                grid[x, selectedRow].TargetPosition = GetCellPosition(x, selectedRow);
            }

            grid[Width - 1, selectedRow] = first;
            first.LocalPosition = GetCellPosition(Width, selectedRow);
            first.TargetPosition = GetCellPosition(Width - 1, selectedRow);

        }

        public void ShiftRowRight(int selectedRow)
        {
            Jewel last = grid[Width - 1, selectedRow];
            for(int x = Width - 1; x > 0; x--)
            {
                grid[x, selectedRow] = grid[x - 1, selectedRow];
                grid[x, selectedRow].TargetPosition = GetCellPosition(x, selectedRow);
            }

            grid[0, selectedRow] = last;
            last.LocalPosition = GetCellPosition(-1, selectedRow);
            last.TargetPosition = GetCellPosition(0, selectedRow);
        }

        bool IsValidCombination(Jewel a, Jewel b, Jewel c)
        {
            return IsConditionValid(a.ColorType, b.ColorType, c.ColorType)
                && IsConditionValid(a.ShapeType, b.ShapeType, c.ShapeType)
                && IsConditionValid(a.NumberType, b.NumberType, c.NumberType);
        }

        bool IsConditionValid(int a, int b, int c)
        {
            return AllEqual(a, b, c) || AllDifferent(a, b, c);
        }

        bool AllEqual(int a, int b, int c)
        {
            return a == b && b == c;
        }

        bool AllDifferent(int a, int b, int c)
        {
            return a != b && b != c && c != a;
        }

    }
}
