 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Библиотеки для работы с графикой;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;
using System.Drawing.Imaging;
using System.Drawing;

namespace Tetris
{
    class figures
    {
        public static void drawTriangle(int x, int y, int dirq = 0)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            switch (dirq)
            {
                case 0:
                    x1 = x - 1;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    break;
                case 1:
                    x1 = x;
                    x2 = x;
                    x3 = x;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y;
                    break;
                case 2:
                    x1 = x;
                    x2 = x;
                    x3 = x - 1;
                    x4 = x + 1;
                    y1 = y + 1;
                    y2 = y;
                    y3 = y;
                    y4 = y;
                    break;
                case 3:
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

        public static void drawBox(int x, int y, int dirq = 0)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            x1 = x;
            x2 = x + 1;
            x3 = x;
            x4 = x + 1;
            y1 = y;
            y2 = y;
            y3 = y + 1;
            y4 = y + 1;
            figures.drawRec(x1 * 1.2, y1 * 1.2, x1 * 1.2 + 1, y1 * 1.2 + 1);
            figures.drawRec(x2 * 1.2, y2 * 1.2, x2 * 1.2 + 1, y2 * 1.2 + 1);
            figures.drawRec(x3 * 1.2, y3 * 1.2, x3 * 1.2 + 1, y3 * 1.2 + 1);
            figures.drawRec(x4 * 1.2, y4 * 1.2, x4 * 1.2 + 1, y4 * 1.2 + 1);
        }

        public static void drawL(int x, int y, int dirq = 0)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            switch (dirq)
            {
                case 0:
                    x1 = x;
                    x2 = x + 1;
                    x3 = x;
                    x4 = x;
                    y1 = y;
                    y2 = y;
                    y3 = y - 1;
                    y4 = y - 2;
                    break;
                case 1:
                    x1 = x;
                    x2 = x;
                    x3 = x + 1;
                    x4 = x + 2;
                    y1 = y;
                    y2 = y - 1;
                    y3 = y - 1;
                    y4 = y - 1;
                    break;
                case 2:
                    x1 = x;
                    x2 = x + 1;
                    x3 = x + 1;
                    x4 = x + 1;
                    y1 = y;
                    y2 = y;
                    y3 = y + 1;
                    y4 = y + 2;
                    break;
                case 3:
                    x1 = x;
                    x2 = x + 1;
                    x3 = x + 2;
                    x4 = x + 2;
                    y1 = y;
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


        public static void drawRevL(int x, int y, int dirq = 0)
        {
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;
            switch (dirq)
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
                    break;
            }
            figures.drawRec(x1 * 1.2, y1 * 1.2, x1 * 1.2 + 1, y1 * 1.2 + 1);
            figures.drawRec(x2 * 1.2, y2 * 1.2, x2 * 1.2 + 1, y2 * 1.2 + 1);
            figures.drawRec(x3 * 1.2, y3 * 1.2, x3 * 1.2 + 1, y3 * 1.2 + 1);
            figures.drawRec(x4 * 1.2, y4 * 1.2, x4 * 1.2 + 1, y4 * 1.2 + 1);
        }

        public static bool drawRec(double x1, double y1, double x2, double y2)
        {
            x1 += game.GUI_MARGIN;
            x2 += game.GUI_MARGIN;
            if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0)
                return false;
            // активируем режим рисования линий на основе 
            // последовательного соединения всех вершин в отрезки 
            // устанавливаем текущий цвет - красный 
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(x1, y1);
            Gl.glVertex2d(x1, y2);
            Gl.glVertex2d(x2, y2);
            Gl.glVertex2d(x2, y1);
            // завершаем режим рисования 
            Gl.glEnd();

            return true;
        }



        public static void drawText(string text, float x, float y, bool selected = false)
        {
            /* For Text Drawing */
            Bitmap text_bmp;
            BitmapData data;
            uint texture_text = 0;
            int
            textwidth = 100,
            textheight = 24;

            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            textwidth = text.Length * 12;
            // ! Создаем картинку
            text_bmp = new Bitmap(textwidth, textheight);
            // ! Создаем поверхность рисования GDI+ из картинки
            Graphics gfx = Graphics.FromImage(text_bmp); // **************************************************** BUG
            // ! Очищаем поверхность рисования цветом
            if (selected) gfx.Clear(Color.Red);
            // ! Создаем шрифт
            Font font = new Font(FontFamily.GenericSerif, 15f);
            // ! Отрисовываем строку в поверхность рисования (в картинку)
            gfx.DrawString(text, font, Brushes.Black, new PointF(0, 0));
            // ! Вытягиваем данные из картинки
            data = text_bmp.LockBits(new Rectangle(0, 0, text_bmp.Width, text_bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            /*
            // ! Включаем тектстурирование
            Gl.glEnable(Gl.GL_TEXTURE_2D);*/

            // ! Генерируем тектурный ID
            Gl.glGenTextures(1, out texture_text);
            // ! Делаем текстуру текущей
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture_text);
            // ! Настраиваем свойства текстура
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // ! Подгружаем данные из картинки в текстуру
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, text_bmp.Width, text_bmp.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data.Scan0);

            text_bmp.UnlockBits(data);
            /*
            // ! Включаем смешивание
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            */
            // ! Делаем текстру текущей
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture_text);

            // ! Рисуем прямогульник с нашей тектурой, на которой текст
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0f, 1f);
            Gl.glVertex2f(x + 0.5f, y + 0.5f);

            Gl.glTexCoord2f(1f, 1f);
            Gl.glVertex2f(x + textwidth / 10 - 0.5f, y + 0.5f);

            Gl.glTexCoord2f(1f, 0f);
            Gl.glVertex2f(x + textwidth / 10 - 0.5f, y + textheight / 10 - 0.5f);

            Gl.glTexCoord2f(0f, 0f);
            Gl.glVertex2f(x + 0.5f, y + textheight / 10 - 0.5f);
            Gl.glEnd();

        }

        public static void drawtext(string text, int length,int x, int y, bool selected = false)
        {
            double[] matrix = new double[16];
            length = text.Length;
            Gl.glColor3f(0, 0, 0);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, matrix);
            Gl.glRasterPos2i(x+1, y+1);
            for (int i = 0; i < length; i++)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, (int)text[i]);
            }
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadMatrixd(matrix);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            if (selected) drawFillRec(x,y,x+length*12,new int[3] { 255,0,0});
        }

        public static void drawMenuRec(float x, float y, int textwidth = 100)
        {
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(x - 0.5, y - 0.5);
            Gl.glVertex2d(x - 0.5, y + 2.5);
            Gl.glVertex2d(x + textwidth / 10 + 0.5, y + 2.5);
            Gl.glVertex2d(x + textwidth / 10 + 0.5, y - 0.5);
            //Gl.glVertex2d(x-0.5, y-0.5);
            Gl.glEnd();
        }

        public static void drawFillRec(int x, int y, int textwidth, int[] rgb)
        {

            Gl.glColor3f(rgb[0], rgb[1], rgb[2]);
            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(x + 0.5, y);
            Gl.glVertex2d(x + 0.5, y + 2);
            Gl.glVertex2d(x + textwidth / 10 - 0.5, y + 2);
            Gl.glVertex2d(x + textwidth / 10 - 0.5, y);
            /*Gl.glVertex2d(x1 + 0.5, y1 + 0.5);
            Gl.glVertex2d(x2 + 0.5, y1 - 2.5);
            Gl.glVertex2d(x2 - 0.5, y2 - 2.5);
            Gl.glVertex2d(x1 - 0.5, y2 + 0.5);*/
            //Gl.glVertex2d(x-0.5, y-0.5);
            Gl.glEnd();
        }
    }
}
