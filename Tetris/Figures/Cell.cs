using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    class Cell
    {
        public int x, y;
        public int colour;

        public Cell(int x, int y, int colour = 0)
        {
            this.x = x;
            this.y = y;
            this.colour = colour;
        }

        public void Draw()
        {
            figures.drawRec(x * 1.2, y * 1.2, x * 1.2 + 1, y * 1.2 + 1);
        }
    }
}
