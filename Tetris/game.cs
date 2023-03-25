using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
// Библиотеки для работы с графикой;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;
using System.Drawing.Imaging;
using System.Drawing;

namespace Tetris
{
    class game
    {
        public const int
            STATE_PLAYING = 1, // Խաղը ընթացքի մեջ է
            STATE_PAUSE = 0, // Խաղը կանգ է առել
            STATE_SAVING = 2, // Խաղը պահպանվում է
            STATE_NOT_STARTED = 3, // Խաղը դեռ միացված չէ
            STATE_GAME_OVER = 4, // Խաղն ավարտված է
            STATE_CLEARING_ROWS = 5, // Տողերի մաքրում
            STATE_ROWS_ARE_CLEAR = 6, // Տողերը մաքրված են
            FIGURES_QUANTITY = 3, // Ֆիգուրաների քանակը
            HASH_TABLE_WIDTH = 15, // Մատրիցայի Երկարությունը
            HASH_TABLE_HEIGHT = 20; // Մատրիցայի բարձրությունը
        public const double GUI_MARGIN = 1; // Ինտերֆեյսի ձախից բացվածքը :D

        public int
            lowest_row = 0, // Ամենացածր ջնջված տողը 
            state = 0, // Խաղի կարգավիճակ
            ilik = HASH_TABLE_WIDTH, // հեչ
            score = 0, // Խաղի միավորները
            curr_row = 0; // այժմյան ջնջվող տողը
        public int[,]
            hashTable = new int[HASH_TABLE_WIDTH + 5, HASH_TABLE_HEIGHT + 5]; // Խաղի մատրից
        public int[]
            rows_to_remove = new int[HASH_TABLE_HEIGHT], // Ջնջվող տողերը
            currentFigure = new int[2], // Այս պահին ընթացող ֆիգուրայի տվյալները 0 - ֆիգուրայի համարը (Կարող է լինել մինչև FIGURES_QUANTITY) , 1 - Ֆիգուրայի տեսքը (Կարող է լինել 0-3-ը ներառյալ)
            currFigurePosition = new int[2]; // Այս պահին ընթացող ֆիգուրայի կոորդինատները
        private bool
            clear_row = false,  // ջնջել տողը
            changeFigure = true; // փոխել ֆիգուրան
        private bool[] figureNav = new bool[3]; // Figure navigation 0 - Left, 1 - Right, 2 - Bottom

        private Size window_size;

        Random rnd = new Random();
        public game(Size window_size)
        {
            this.state = STATE_PLAYING;
            this.window_size = window_size;
        }

        public void setWindowSize(Size window_size)
        {
            this.window_size = window_size;
        }

        public void play()
        {
            switch (this.state)
            {
                case STATE_PLAYING:
                    if (changeFigure)
                    {
                        currentFigure[0] = rnd.Next(0, FIGURES_QUANTITY);
                        currentFigure[1] = rnd.Next(0, 4);
                        currFigurePosition[0] = rnd.Next(1, HASH_TABLE_WIDTH - 1);
                        currFigurePosition[1] = 1;
                        changeFigure = false;
                    }
                    this.draw();
                    break;
                case STATE_CLEARING_ROWS:
                    this.draw(true);
                    break;
            }
        }

        public void pause()
        {
            this.state = STATE_PAUSE;
        }

        public void save()
        {

        }

        public void startNew()
        {
            hashTable = null;
            hashTable = new int[HASH_TABLE_WIDTH + 5, HASH_TABLE_HEIGHT + 5];
            score = 0;
        }

        public void drawBorders()
        {
            /**
             * Draws game main border.
             */
            figures.drawRec(0, this.window_size.Height * 10, (HASH_TABLE_WIDTH * figures.multiplier), (HASH_TABLE_HEIGHT * figures.multiplier) - this.window_size.Height);
            //figures.drawRec(0, this.window_size.Height - 1, HASH_TABLE_WIDTH * figures.multiplier, this.window_size.Height - (HASH_TABLE_HEIGHT * figures.multiplier));
        }

        public void draw(bool clearingrows = false)
        {
            this.drawBorders();
            for (int i = 0; i < HASH_TABLE_WIDTH; i++)
            {
                for (int j = 0; j <= HASH_TABLE_HEIGHT; j++)
                {
                    if (this.hashTable[i, j] == 1)
                        figures.drawRec(i * figures.multiplier, j * figures.multiplier, i * figures.multiplier + 1, j * figures.multiplier + 1);
                }
            }
            if (!clearingrows)
                drawFigure();
            figures.drawtext("Score: "+this.score,5, (int)Math.Floor(GUI_MARGIN) + HASH_TABLE_WIDTH + 5, HASH_TABLE_HEIGHT);
            
        }

        public void drawFigure()
        {
            switch (currentFigure[0])
            {
                case 0: // T-Block
                    figures.drawTriangle(currFigurePosition[0], currFigurePosition[1], currentFigure[1]);
                    break;
                case 1: // O-Block
                    figures.drawBox(currFigurePosition[0], currFigurePosition[1], currentFigure[1]);
                    break;
                case 2: // J-Block
                    figures.drawL(currFigurePosition[0], currFigurePosition[1], currentFigure[1]);
                    break;
                    // TODO remaining blocks
                    /**
                     *  I-block
	                        ***
                        L-Block
	                          *
	                        ***
                        S-block
	                         **
	                        **
                        Z-Block
	                        **
	                         **
                     */
            }
        }

        public void decorateFigure()
        {
            this.currentFigure[1]++;
            if (this.currentFigure[1] > 3)
                this.currentFigure[1] = 0;
        }

        public void moveFigure(int where)
        {
            if (this.state == STATE_PLAYING)
            {
                this.checkHashTable();
                switch (where)
                {
                    case 0:
                        if (currFigurePosition[0] > 0 && figureNav[0])
                            currFigurePosition[0]--;
                        break;
                    case 1:
                        if (currFigurePosition[0] < HASH_TABLE_WIDTH && figureNav[1])
                            currFigurePosition[0]++;
                        break;
                    case 2:
                        if (currFigurePosition[0] < HASH_TABLE_HEIGHT - 1 && figureNav[2])
                            currFigurePosition[1]++;
                        break;
                }
            }
        }

        public void calculate()
        {

            if (this.state == game.STATE_PLAYING)
            {
                Thread.Sleep(500);
                this.checkHashTable();
                if (figureNav[2])
                    currFigurePosition[1]++;
            }
            if (this.state == STATE_CLEARING_ROWS)
            {
                Thread.Sleep(30);
                if (ilik >= 0) hashTable[ilik, this.rows_to_remove[curr_row]] = 0;
                if (ilik > 0 && rows_to_remove[curr_row] != 0)
                    ilik--;
                else if (ilik == 0)
                {
                    this.state = STATE_ROWS_ARE_CLEAR;
                    this.lowest_row = rows_to_remove[curr_row];
                    ilik--;
                    score += 10;
                }
                else
                {
                    ilik = HASH_TABLE_WIDTH;
                    curr_row++;
                }
                if (curr_row == HASH_TABLE_HEIGHT) this.state = STATE_PLAYING;
            }
            if (this.state == STATE_ROWS_ARE_CLEAR)
            {
                for (int j = 1; j < rows_to_remove[curr_row] - 1; j++)
                    for (int i = 0; i <= HASH_TABLE_WIDTH; i++)
                    {
                        hashTable[i, lowest_row - j + 1] = hashTable[i, lowest_row - j];
                    }
                this.state = STATE_CLEARING_ROWS;
            }
        }

        public void checkHashTable()
        {
            for (int i = 0; i <= HASH_TABLE_WIDTH; i++)
            {
                if (this.hashTable[i, 0] == 1)
                    this.state = STATE_GAME_OVER;
            }
            switch (currentFigure[0])
            {
                case 0:
                    this.figureNav = hashtabcheck.triangle(ref this.hashTable, ref this.currentFigure[1], ref currFigurePosition[0], ref currFigurePosition[1]);
                    break;
                case 1:
                    this.figureNav = hashtabcheck.Box(ref this.hashTable, ref this.currentFigure[1], ref currFigurePosition[0], ref currFigurePosition[1]);
                    break;
                case 2:
                    this.figureNav = hashtabcheck.L(ref this.hashTable, ref this.currentFigure[1], ref currFigurePosition[0], ref currFigurePosition[1]);
                    break;
            }
            if (!figureNav[2])
            {
                changeFigure = true;
            }

            this.rows_to_remove = hashtabcheck.HashTable(ref hashTable, ref clear_row);
            if (clear_row) { this.state = STATE_CLEARING_ROWS; curr_row = 0; }
        }
    }
}