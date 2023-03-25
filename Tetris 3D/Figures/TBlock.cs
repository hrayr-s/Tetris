using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Properties;

namespace Tetris.Figures
{
    public class TBlock : BaseFigure<TBlock>
    {

        public TBlock()
        {
            cells[0] = new Cell(0, 1, 0);
            cells[1] = new Cell(1, 0, 0);
            cells[2] = new Cell(1, 1, 0);
            cells[3] = new Cell(2, 1, 0);
        }

        public override void PositionTop()
        {
            /**
             * Draws figure T in position Up
             *                      |
             *                     ---
             */
            cells[0].x = 0;            cells[0].y = 1;
            cells[1].x = 1;            cells[1].y = 0;
            cells[2].x = 1;            cells[2].y = 1;
            cells[3].x = 2;            cells[3].y = 1;
        }

        public override void PositionLeft()
        {
            /**
             * Draws figure T in position Left
             *                      -|
             */
            cells[0].x = 0;            cells[0].y = 1;
            cells[1].x = 1;            cells[1].y = 0;
            cells[2].x = 1;            cells[2].y = 1;
            cells[3].x = 1;            cells[3].y = 2;
        }

        public override void PositionBottom()
        {
            /**
             * Draws figure T in position Down
             *                     ---
             *                      |
             */
            cells[0].x = 0; cells[0].y = 0;
            cells[1].x = 1; cells[1].y = 0;
            cells[2].x = 2; cells[2].y = 0;
            cells[3].x = 1; cells[3].y = 1;
        }

        public override void PositionRight()
        {
            /**
             * Draws figure T in position Right
             *                      |-
             */
            cells[0].x = 0; cells[0].y = 0;
            cells[1].x = 0; cells[1].y = 1;
            cells[2].x = 0; cells[2].y = 2;
            cells[3].x = 1; cells[3].y = 1;
        }

    }
}
