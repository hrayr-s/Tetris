using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Библиотеки для работы с графикой;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;
using System.Drawing.Imaging;

namespace Tetris
{
    class menu 
    {
        public int selitem = 2,
            lastcoord = 0;
        public bool startNEWgame = false;
        public string[] menulist = new string[3];

        public menu(ref int gamestate)
        {
            menulist[2] = "Start new Game";
            menulist[1] = "Continue Game";
            menulist[0] = "Exit";
        }

        public void selectItem(ref int gamestate, int laststate)
        {
            switch (selitem)
            {
                case 0:
                    // Завершим приложение;
                    Application.Exit();
                    break;
                case 2:
                    gamestate = laststate;
                    break;
                case 3:
                    gamestate = game.STATE_PLAYING;
                    startNEWgame = true;
                    break;
            }
        }

        public void draw()
        {
            for (int i = 2, j = 0; i <= 13; i += 5, j++)
            {

                if (selitem == j)
                    figures.drawtext(menulist[j], menulist[j].Length, 2, i, true);
                else
                    figures.drawtext(menulist[j], menulist[j].Length, 2, i);
                figures.drawMenuRec(2, i, menulist[j].Length * 12);
            }
        }
    }
}
