using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Random rndx = new Random();
        Random rndy = new Random();
        Task mm, calc;
        // Флаг полноэкранного режима;
        private bool FS = false;
        string
            view = "menu";
        menu men;
        game game;
        int gamestate = 3,
            thewindowwidth,
            laststate=game.STATE_PLAYING;
        debug debcons;
        public bool
            startgame = false,
            gameLoaded = false,
            gameloading = false,
            calcStarted = false;
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            men = new menu(ref gamestate);
            // Разворачиваем окно;
            this.WindowState = FormWindowState.Maximized;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // инициализация библиотеки GLUT 
            Glut.glutInit();
            // инициализация режима окна 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // устанавливаем цвет очистки окна 
            Gl.glClearColor(255, 255, 255, 1);

            // устанавливаем порт вывода, основываясь на размерах элемента управления AnT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // устанавливаем проекционную матрицу
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            // очищаем ее 
            Gl.glLoadIdentity();

            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            // в зависимости от того, какая сторона больше 
            // мы немного варьируем то, как будут сконфигурированы настройки проекции 
            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);

            // переходим к объектно-видовой матрице 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            // ! Включаем тектстурирование
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            thewindowwidth = AnT.Width;

            // ! Включаем смешивание
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);


            refreshtimer.Start();
            mm = Task.Run(() => {
                while (true)
                {
                    Thread.Sleep(100);

                    if (this.view == "menu" && gameLoaded) game.state = this.gamestate;
                    if (this.view == "game") this.gamestate = game.state;
                    if (this.gamestate == game.STATE_PLAYING || this.gamestate == game.STATE_CLEARING_ROWS)
                    {
                        if (!gameLoaded)
                        {
                            if (this.game == null)
                                this.game = new Tetris.game();
                            if (!this.gameLoaded)
                                this.gameLoaded = true;
                        }
                        if (this.view != "game")
                            this.view = "game";
                    }
                }
            });
            

            this.FormBorderStyle = FormBorderStyle.None;
        }

        // Смена режима (Fullscreen/Window)
        private void ScreenMode(bool fullscreen)
        {
            // Присваиваем значение "глобальной" переменной;
            FS = fullscreen;

            if (FS)
            {   // *** ПОЛНОЭКРАННЫЙ РЕЖИМ ***
                // Скрываем рамку окна;
                this.FormBorderStyle = FormBorderStyle.None;
                // Разворачиваем окно;
                this.WindowState = FormWindowState.Maximized;
                // --- Не обязательный пункт --- 
                // Делаем курсор в форме руки;
                // TaoWin.Cursor = Cursors.Hand;
            }
            else
            {   // *** ОКОННЫЙ РЕЖИМ ***
                // Возвращаем состояние окна;
                this.WindowState = FormWindowState.Normal;
                // Показываем масштабируемую рамку окна;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                // --- Не обязательный пункт ---
                // Возвращаем курсор по-умолчанию;
                // TaoWin.Cursor = Cursors.Default;
                // Задаем размеры окна;
                this.Width = 1280;   // Ширина;
                this.Height = 720;  // Высота;
            }
            //form1sizechanged();
        }

        public void draw()
        {


            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // очищаем текущую матрицу 
            Gl.glLoadIdentity();
        
            if (gamestate != game.STATE_PLAYING && this.view == "menu")
                men.draw();

            if (gameLoaded && (gamestate == game.STATE_PLAYING || this.gamestate == game.STATE_CLEARING_ROWS) && this.view == "game")
            {
                if (men.startNEWgame)
                {
                    game.startNew();
                    men.startNEWgame = false;
                }
                game.play();
                if (!calcStarted)
                {
                    calc = new Task(delegate { while (true) game.calculate(); });
                    calc.Start();
                    calcStarted = true;
                }

            }
            //men.drawText(rndx.Next(0, 2) + "Su", 10,  10);

            Gl.glFlush();
            // дожидаемся конца визуализации кадра 

            // посылаем сигнал перерисовки элемента AnT. 
            AnT.Invalidate();
        }

        private void form1sizechanged(object sender, EventArgs e)
        {
            // инициализация режима окна 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // устанавливаем цвет очистки окна 
            Gl.glClearColor(255, 255, 255, 1);

            // устанавливаем порт вывода, основываясь на размерах элемента управления AnT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // устанавливаем проекционную матрицу 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очищаем ее 
            Gl.glLoadIdentity();

            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            // в зависимости от того, какая сторона больше 
            // мы немного варьируем то, как будут сконфигурированы настройки проекции 
            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);

            // переходим к объектно-видовой матрице 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            //MessageBox.Show("Forma "+ilik);
        }

        private void refreshtimer_Tick(object sender, EventArgs e)
        {
            this.draw();
        }


        // События нажатий клавиш клавиатуры; 
        private void FormFS_KeyUp(object sender, KeyEventArgs e)
        {
            #region EXIT
            // Нажата клавиша ЕSCAPE;
            /*if (e.KeyCode == Keys.Escape)
            {
                // Завершим приложение;
                this.Close();
            }*/
            #endregion

            #region Полноэкранный или оконный режим
            // Нажата клавиша F2;
            if (e.KeyCode == Keys.F2)
            {
                // Изменяем режим на ПОЛНОЭКРАННЫЙ;
                ScreenMode(true);
                // Прячем курсор;
                Cursor.Hide();
            }
            // Нажата клавиша F1;
            if (e.KeyCode == Keys.F1)
            {
                // Изменяем режим на оконный;
                ScreenMode(false);
                // Показываем курсор;
                Cursor.Show();
            }
            #endregion

            #region Menu Navigation
            if (view == "menu")
            {
                if (e.KeyCode == Keys.Up)
                {
                    men.selitem++;
                    if (men.selitem >= men.menulist.Length) men.selitem = 0;
                }
                if (e.KeyCode == Keys.Down)
                {
                    men.selitem--;
                    if (men.selitem < 0) men.selitem = men.menulist.Length - 1;
                }
                if (e.KeyCode == Keys.Return)
                {
                    men.selectItem(ref this.gamestate,laststate);
                }
            }
            #endregion
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            #region Game Navigation
            if (view == "game")
            {
                if (e.KeyCode == Keys.Space)
                {
                    game.decorateFigure();
                }
                if (e.KeyCode == Keys.A)
                {
                    game.moveFigure(0);
                }
                if (e.KeyCode == Keys.D)
                {
                    game.moveFigure(1);
                }
                if (e.KeyCode == Keys.W)
                {
                    game.moveFigure(2);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    laststate = gamestate;
                    this.gamestate = game.STATE_PAUSE;
                    this.view = "menu";
                }
            }
            #endregion
        }



    }
}
