using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class RowSelector : SpriteGameObject
    {
        //variables
        int selectedRow;
        JewelGrid grid;

        //constructors
        public RowSelector(JewelGrid grid) : base("spr_selector_frame")
        {
            this.grid = grid;
            selectedRow = 0;
            origin = new Vector2(10, 10);
        }

        //props

        //monogame methods
        public override void Update(GameTime gameTime)
        {
            
        }

        //methods
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Up) || inputHelper.KeyPressed(Keys.W))
                selectedRow--;
            else if (inputHelper.KeyPressed(Keys.Down) || inputHelper.KeyPressed(Keys.S))
                selectedRow++;
            selectedRow = MathHelper.Clamp(selectedRow, 0, grid.Height - 1);

            LocalPosition = grid.GetCellPosition(0, selectedRow);

            if (inputHelper.KeyPressed(Keys.Left) || inputHelper.KeyPressed(Keys.A))
                grid.ShiftRowLeft(selectedRow);
            if (inputHelper.KeyPressed(Keys.Right) || inputHelper.KeyPressed(Keys.D))
                grid.ShiftRowRight(selectedRow);
        }
    }
}
