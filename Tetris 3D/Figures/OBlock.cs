using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    public class OBlock : BaseFigure<OBlock>
    {
        public OBlock()
        {
            cells[0] = new Cell(0, 0, 0);
            cells[1] = new Cell(1, 0, 0);
            cells[2] = new Cell(0, 1, 0);
            cells[3] = new Cell(1, 1, 0);
        }

        public override void PositionTop() { }
        public override void PositionBottom() { }
        public override void PositionLeft() { }
        public override void PositionRight() { }
    }
}
