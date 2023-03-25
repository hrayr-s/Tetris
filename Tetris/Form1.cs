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
            // this.WindowState = FormWindowState.Maximized;
            this.ScreenMode(true);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();
            
            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glEnable(Gl.GL_TEXTURE_2D);

            thewindowwidth = AnT.Width;

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
                                this.game = new Tetris.game(this.gameDrawSize());
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

        // Change window mode (Fullscreen/Window)
        private void ScreenMode(bool fullscreen)
        {
            FS = fullscreen;
            if (FS)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                // TaoWin.Cursor = Cursors.Hand;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Width = 1280;
                this.Height = 720;
            }
        }

        public void draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
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
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void form1sizechanged(object sender, EventArgs e)
        {
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            AnT.Size = new System.Drawing.Size(this.Width, this.Height);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            if (gameLoaded)
            {
                this.game.setWindowSize(this.gameDrawSize());
            }
        }

        private Size gameDrawSize()
        {
            return new Size(this.Size.Width / this.AnT.LogScaleX, this.Size.Height / this.AnT.LogScaleY);
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
