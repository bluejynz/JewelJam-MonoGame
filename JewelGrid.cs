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

        //methods
        public override void Reset()
        {
            grid = new Jewel[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    AddJewel(x, y);
                }
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (!inputHelper.KeyPressed(Keys.Space))
                return;

            int extraScore = 45;
            int mid = Width / 2;
            for(int y = 0; y < Height - 2; y++)
            {
                if (IsValidCombination(grid[mid, y], grid[mid, y + 1], grid[mid, y + 2]))
                {
                    JewelJam.GameWorld.AddScore(extraScore);
                    extraScore *= 3;

                    RemoveJewel(mid, y);
                    RemoveJewel(mid, y + 1);
                    RemoveJewel(mid, y + 2);
                    y += 2;
                }
            }
        }

        void RemoveJewel(int x, int y)
        {
            for (int row = y; row > 0; row--)
            {
                grid[x, row] = grid[x, row - 1];
                grid[x, row].LocalPosition = GetCellPosition(x, row);
            }

            AddJewel(x, 0);
        }

        void AddJewel(int x, int y)
        {
            grid[x, y] = new Jewel();
            grid[x, y].LocalPosition = GetCellPosition(x, y);
            grid[x, y].Parent = this;
        }

        void MoveRowsDown()
        {
            for (int y = Height - 1; y > 0; y--)
                for (int x = 0; x < Width; x++)
                {
                    grid[x, y] = grid[x, y - 1];
                    grid[x, y].LocalPosition = GetCellPosition(x, y);
                }

            for (int x = 0; x < Width; x++)
            {
                grid[x, 0] = new Jewel();
                grid[x, 0].LocalPosition = GetCellPosition(x, 0);
                grid[x, 0].Parent = this;
            }
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
                grid[x, selectedRow].LocalPosition = GetCellPosition(x, selectedRow);
            }

            grid[Width - 1, selectedRow] = first;
            grid[Width - 1, selectedRow].LocalPosition = GetCellPosition(Width - 1, selectedRow);

        }

        public void ShiftRowRight(int selectedRow)
        {
            Jewel last = grid[Width - 1, selectedRow];
            for(int x = Width - 1; x > 0; x--)
            {
                grid[x, selectedRow] = grid[x - 1, selectedRow];
                grid[x, selectedRow].LocalPosition = GetCellPosition(x, selectedRow);
            }

            grid[0, selectedRow] = last;
            grid[0, selectedRow].LocalPosition = GetCellPosition(0, selectedRow);
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
