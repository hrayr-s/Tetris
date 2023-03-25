using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Properties;

namespace Tetris.Figures
{
    class TBlock : BaseFigure
    {
        private int x = -1;
        private int y = -1;
        private FigurePose figurePosing = FigurePose.Top;
        private readonly Cell[] cells;

        internal static TBlock Instance { get; set; } = null;

        private TBlock()
        {
            //Settings.Default[""]
            cells = new Cell[4];
            cells[0] = new Cell(0, 1, 0);
            cells[1] = new Cell(1, 0, 0);
            cells[2] = new Cell(2, 1, 0);
            cells[3] = new Cell(3, 1, 0);
        }

        public static TBlock GetInstance()
        {
            if (Instance == null)
            {
                TBlock.Instance = new TBlock();
            }
            return TBlock.Instance;
        }

        public void Draw()
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            switch (this.figurePosing)
            {
                case FigurePose.Top:
                    x1 = x - 1;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    break;
                case FigurePose.Right:
                    x1 = x;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    break;
                case FigurePose.Bottom:
                    x1 = x;
                    x2 = x;
                    x3 = x - 1;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y;
                    y4 = y;
                    break;
                case FigurePose.Left:
                    x1 = x;
                    x2 = x;
                    x3 = x - 1;
                    x4 = x;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y;
                    y4 = y - 1;
                    break;
            }
            figures.drawRec(x1 * 1.2, y1 * 1.2, x1 * 1.2 + 1, y1 * 1.2 + 1);
            figures.drawRec(x2 * 1.2, y2 * 1.2, x2 * 1.2 + 1, y2 * 1.2 + 1);
            figures.drawRec(x3 * 1.2, y3 * 1.2, x3 * 1.2 + 1, y3 * 1.2 + 1);
            figures.drawRec(x4 * 1.2, y4 * 1.2, x4 * 1.2 + 1, y4 * 1.2 + 1);
        }

        private void DrawPositionTop()
        {
            /**
             * Draws figure T in position Up
             *                      |
             *                     ---
             */
        }

        private void DrawPositionLeft()
        {
            /**
             * Draws figure T in position Left
             *                      -|
             */
        }

        private void DrawPositionDown()
        {
            /**
             * Draws figure T in position Down
             *                     ---
             *                      |
             */
        }

        private void DrawPositionRight()
        {
            /**
             * Draws figure T in position Right
             *                      |-
             */
        }

        public void ResetPosition()
        {
            TBlock.Instance.x = 0;
            TBlock.Instance.y = 0;
        }

        public void ChangePose()
        {

        }

        public void GetCurrentPose()
        {

        }

        public void ChooseThisFigure()
        {
            TBlock.Instance.ResetPosition();
        }

    }
}
