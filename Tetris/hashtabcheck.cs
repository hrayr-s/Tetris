using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class hashtabcheck
    {
        public static bool[] triangle(ref int[,] hashtab, ref int decor, ref int x, ref int y)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            bool left = true, right = true, bottom = true;
            switch (decor)
            {
                case 0:
                    if (x == 0) x = 1;
                    if (x >= game.HASH_TABLE_WIDTH - 1) x--;
                    x1 = x - 1;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (hashtab[x4 + 1, y4] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x4, y4 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 1:
                    if (x + 1 > game.HASH_TABLE_WIDTH) x--;
                    x1 = x;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    if (x1 > 0)
                        if (hashtab[x1 - 1, y1] == 1 || (hashtab[x2 - 1, y2] == 1) || hashtab[x3 - 1, y3] == 1) left = false;
                    if (hashtab[x4 + 1, y4] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x4, y4 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT - 1)
                        bottom = false;
                    break;
                case 2:
                    if (x == 0) x = 1;
                    x1 = x;
                    x2 = x;
                    x3 = x - 1;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y;
                    y4 = y;
                    if (x3 > 0)
                    {
                        if (hashtab[x3 - 1, y3] == 1) left = false;
                    }
                    else
                        left = false;
                    if (hashtab[x4 + 1, y4] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x1, y1 + 1] == 1 || hashtab[x2, y2 + 1] == 1 || hashtab[x3, y3 + 1] == 1 || y == game.HASH_TABLE_HEIGHT - 1)
                        bottom = false;
                    break;
                case 3:
                    if (x == 0) x = 1;
                    x1 = x;
                    x2 = x;
                    x3 = x - 1;
                    x4 = x;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y;
                    y4 = y - 1;
                    if (x3 > 1)
                    {
                        if (hashtab[x3 - 1, y3] == 1) left = false;
                    }
                    else
                        if (x3 == 0)
                        left = false;
                    if (hashtab[x1 + 1, y1] == 1 || hashtab[x2 + 1, y2] == 1 || hashtab[x4 + 1, y4] == 1 || x >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x1, y1 + 1] == 1 || hashtab[x2, y2 + 1] == 1 || hashtab[x3, y3 + 1] == 1 || y == game.HASH_TABLE_HEIGHT - 1)
                        bottom = false;
                    break;
            }
            if (!bottom)
            {
                hashtab[x1, y1] = 1;
                hashtab[x2, y2] = 1;
                hashtab[x3, y3] = 1;
                hashtab[x4, y4] = 1;
            }
            return new bool[3] { left, right, bottom };
        }

        public static bool[] Box(ref int[,] hashtab, ref int decor, ref int x, ref int y)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            bool left = true, right = true, bottom = true;
            x1 = x;
            x2 = x + 1;
            x3 = x;
            x4 = x + 1;
            y1 = y;
            y2 = y;
            y3 = y + 1;
            y4 = y + 1;
            if ((hashtab[x3, y3 + 1] == 1) || (hashtab[x4, y4 + 1] == 1) || (y == game.HASH_TABLE_HEIGHT - 1))
                bottom = false;
            if (x3 > 1)
                if (hashtab[x3 - 1, y3] == 1 || hashtab[x3 - 1, y2] == 1)
                    left = false;
            if (hashtab[x2 + 1, y1] == 1 || hashtab[x2 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1)
                right = false;

            if (!bottom)
            {
                hashtab[x1, y1] = 1;
                hashtab[x2, y2] = 1;
                hashtab[x3, y3] = 1;
                hashtab[x4, y4] = 1;
            }
            return new bool[3] { left, right, bottom };
        }

        public static bool[] L(ref int[,] hashtab, ref int decor, ref int x, ref int y)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            bool left = true, right = true, bottom = true;
            switch (decor)
            {
                case 0:
                    if (x < 0) x = 1;
                    if (x >= game.HASH_TABLE_WIDTH - 1) x--;
                    x1 = x;
                    x2 = x + 1;
                    x3 = x;
                    x4 = x;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y - 2;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (y4 >= 0)
                        if (hashtab[x4 + 1, y4] == 1 || hashtab[x3 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 1:
                    if (x >= game.HASH_TABLE_WIDTH - 2) x = game.HASH_TABLE_WIDTH - 3;
                    x1 = x;
                    x2 = x;
                    x3 = x + 1;
                    x4 = x + 2;
                    y1 = y;
                    y2 = y - 1;
                    y3 = y - 1;
                    y4 = y - 1;
                    if (x1 > 0)
                        if (hashtab[x1 - 1, y1] == 1 || (hashtab[x2 - 1, y2] == 1)) left = false;
                    if (hashtab[x4 + 1, y4] == 1 || hashtab[x1 + 1, y1] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x1, y1 + 1] == 1 || hashtab[x4, y4 + 1] == 1 || hashtab[x3, y3 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 2:
                    if (x < 0) x = 1;
                    x1 = x;
                    x2 = x + 1;
                    x3 = x + 1;
                    x4 = x + 1;
                    y1 = y;
                    y2 = y;
                    y3 = y + 1;
                    y4 = y + 2;
                    if (x1 > 0)
                    {
                        if (hashtab[x3 - 1, y3] == 1 || hashtab[x4 - 1, y4] == 1 || hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (hashtab[x3 + 1, y3] == 1 || hashtab[x4 + 1, y4] == 1 || hashtab[x2 + 1, y1] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x1, y1 + 1] == 1 || hashtab[x4, y4 + 1] == 1 || y == game.HASH_TABLE_HEIGHT - 2)
                        bottom = false;
                    break;
                case 3:
                    if (x < 0) x = 1;
                    if (x >= game.HASH_TABLE_WIDTH - 2) x = game.HASH_TABLE_WIDTH - 3;
                    x1 = x;
                    x2 = x + 1;
                    x3 = x + 2;
                    x4 = x + 2;
                    y1 = y;
                    y2 = y;
                    y3 = y;
                    y4 = y - 1;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1 || hashtab[x4 - 1, y4] == 1) left = false;
                    }
                    else
                        left = false;
                    if (hashtab[x3 + 1, y3] == 1 || hashtab[x4 + 1, y4] == 1 || x4 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x1, y1 + 1] == 1 || hashtab[x2, y2 + 1] == 1 || hashtab[x3, y3 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
            }
            if (!bottom)
            {
                hashtab[x1, y1] = 1;
                hashtab[x2, y2] = 1;
                hashtab[x3, y3] = 1;
                hashtab[x4, y4] = 1;
            }
            return new bool[3] { left, right, bottom };
        }

        public static bool[] RevL(ref int[,] hashtab, ref int decor, ref int x, ref int y)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            bool left = true, right = true, bottom = true;
            switch (decor)
            {
                case 0:
                    x1 = x;
                    x2 = x - 1;
                    x3 = x;
                    x4 = x;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y - 2;
                    if (x2 > 0)
                    {
                        if (hashtab[x2 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (y4 >= 0)
                        if (hashtab[x4 + 1, y4] == 1 || hashtab[x3 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 1:
                    x1 = x;
                    x2 = x;
                    x3 = x + 1;
                    x4 = x + 2;
                    y1 = y;
                    y2 = y + 1;
                    y3 = y + 1;
                    y4 = y + 1;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (y4 >= 0)
                        if (hashtab[x4 + 1, y4] == 1 || hashtab[x3 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 2:
                    x1 = x;
                    x2 = x - 1;
                    x3 = x - 1;
                    x4 = x - 1;
                    y1 = y;
                    y2 = y;
                    y3 = y + 1;
                    y4 = y + 2;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (y4 >= 0)
                        if (hashtab[x4 + 1, y4] == 1 || hashtab[x3 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
                case 3:
                    x1 = x;
                    x2 = x - 1;
                    x3 = x - 2;
                    x4 = x - 2;
                    y1 = y;
                    y2 = y;
                    y3 = y;
                    y4 = y - 1;
                    if (x1 > 0)
                    {
                        if (hashtab[x1 - 1, y1] == 1) left = false;
                    }
                    else
                        left = false;
                    if (y4 >= 0)
                        if (hashtab[x4 + 1, y4] == 1 || hashtab[x3 + 1, y3] == 1 || x2 >= game.HASH_TABLE_WIDTH - 1) right = false;
                    if (hashtab[x2, y2 + 1] == 1 || hashtab[x1, y1 + 1] == 1 || y == game.HASH_TABLE_HEIGHT)
                        bottom = false;
                    break;
            }

            return new bool[3] { left, right, bottom };
        }

        public static int[] HashTable(ref int[,] hashtab, ref bool clear_row)
        {
            int k, m = -1;
            int[] mas = new int[game.HASH_TABLE_HEIGHT];
            for (int i = 0; i <= game.HASH_TABLE_HEIGHT; i++)
            {
                k = 0;
                for (int j = 0; j < game.HASH_TABLE_WIDTH; j++)
                {
                    if (hashtab[j, i] == 1) k++;
                }
                if (k == game.HASH_TABLE_WIDTH)
                {
                    clear_row = true;
                    //hashtab[100, 100] = 0;
                    m++;
                    mas[m] = i;
                }
            }
            if (m == -1) clear_row = false;
            return mas;
        }
    }
}
