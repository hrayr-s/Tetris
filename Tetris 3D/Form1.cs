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
using System.Diagnostics;
using Tetris.Figures;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Random rndx = new Random();
        Random rndy = new Random();


        static float X = -5.0f;        // Translate screen to x direction (left or right)
        static float Y = 10.0f;        // Translate screen to y direction (up or down)
        static float Z = -20.0f;        // Translate screen to z direction (zoom in or out)
        private float rotX = -10.0f;    // Rotate screen on x axis 
        private float rotY = 0.0f;    // Rotate screen on y axis
        private float rotZ = -5.0f;    // Rotate screen on z axis

        static float rotLx = 5.0f;   // Translate screen by using the glulookAt function 
                                     // (left or right)
        static float rotLy = 500.0f;   // Translate screen by using the glulookAt function 
                                     // (up or down)
        static float rotLz = -10.0f;   // Translate screen by using the glulookAt function 
                                     // (zoom in or out)

        Task mm, calc;
        // FullScreen flag
        private bool FS = false;
        string
            view = "menu";
        int gamestate = 3,
            thewindowwidth;
        public bool
            startgame = false,
            gameLoaded = false,
            gameloading = false,
            calcStarted = false;
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            this.ScreenMode(true);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);  


            Gl.glShadeModel(Gl.GL_SMOOTH);     // Set the shading model to smooth 
            Gl.glClearColor(0, 0, 0, 0.0f);    // Clear the Color
            // Clear the Color and Depth Buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearDepth(1.0f);          // Set the Depth buffer value (ranges[0,1])
            Gl.glEnable(Gl.GL_DEPTH_TEST);  // Enable Depth test
            Gl.glDepthFunc(Gl.GL_LEQUAL);   // If two objects on the same coordinate 
                                            // show the first drawn
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            thewindowwidth = AnT.Width;


            refreshtimer.Start();
            //mm = Task.Run(() => {
                
            //});
            

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

        private void lines()
        {

            // Draw the positive side of the lines x,y,z
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);                // Green for x axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(10f, 0f, 0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);                // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 10f, 0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);                // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 10f);
            Gl.glEnd();

            // Dotted lines for the negative sides of x,y,z coordinates
            Gl.glEnable(Gl.GL_LINE_STIPPLE); // Enable line stipple to use a 
                                             // dotted pattern for the lines
            Gl.glLineStipple(1, 0x0101);     // Dotted stipple pattern for the lines
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);                    // Green for x axis
            Gl.glVertex3f(-10f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);                    // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, -10f, 0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);                    // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, -10f);
            Gl.glEnd();
        }

        public void draw()
        {
            // Clear the Color Buffer and Depth Buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();   // It is important to push the Matrix before 
                                 // calling glRotatef and glTranslatef

            Gl.glLoadIdentity();

            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);            // Rotate on x
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);            // Rotate on y
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);            // Rotate on z

            Gl.glTranslatef(X, Y, Z);        // Translates the screen left or right, 
                                             // up or down or zoom in zoom out
            this.lines();
            OBlock.Draw();

            
            Gl.glDisable(Gl.GL_LINE_STIPPLE);   // Disable the line stipple
            Gl.glPopMatrix();                   // Don't forget to pop the Matrix

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void cameraPositionChanged()
        {

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(rotLx, rotLy, 15.0f +
                     rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        private void form1sizechanged(object sender, EventArgs e)
        {
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            AnT.Size = new System.Drawing.Size(this.Width, this.Height);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);


            Gl.glMatrixMode(Gl.GL_PROJECTION);        // Set the Matrix mode
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)AnT.Width / (float)AnT.Height, 0.10f, 500.0f);
            this.cameraPositionChanged();
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
            if (e.KeyCode == Keys.Escape)
            {
                // Завершим приложение;
                this.Close();
            }
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
                    // men.selitem++;
                    // if (men.selitem >= men.menulist.Length) men.selitem = 0;
                }
                if (e.KeyCode == Keys.Down)
                {
                    // men.selitem--;
                    // if (men.selitem < 0) men.selitem = men.menulist.Length - 1;
                }
                if (e.KeyCode == Keys.Return)
                {
                    // men.selectItem(ref this.gamestate,laststate);
                }
            }
            #endregion
        }

        private void AnT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine(e.KeyCode.ToString());

            switch (e.KeyCode)
            {
                case Keys.Up:
                    Y -= 1;
                    break;
                case Keys.Down:
                    Y += 1;
                    break;
                case Keys.Left:
                    X += 1;
                    break;
                case Keys.Right:
                    X -= 1;
                    break;

                case Keys.Z:
                    OBlock.ChangePose();
                    break;


            }
        }

        private void FormFS_KeyDown(object sender, KeyEventArgs e)
        {

            #region Game Navigation
            if (view == "game")
            {
                if (e.KeyCode == Keys.Space)
                {
                    // game.decorateFigure();
                }
                if (e.KeyCode == Keys.A)
                {
                    // game.moveFigure(0);
                }
                if (e.KeyCode == Keys.D)
                {
                    // game.moveFigure(1);
                }
                if (e.KeyCode == Keys.W)
                {
                    // game.moveFigure(2);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    // laststate = gamestate;
                    // this.gamestate = game.STATE_PAUSE;
                    this.view = "menu";
                }



            }
            #endregion

            switch(e.KeyCode)
            {
                case Keys.Up:
                    Y -= 1;
                    break;
                case Keys.Down:
                    Y += 1;
                    break;
                case Keys.Left:
                    X += 1;
                    break;
                case Keys.Right:
                    X -= 1;
                    break;


                case Keys.W:
                    this.rotX += 1f;
                    this.cameraPositionChanged();
                    break;
                case Keys.S:
                    this.rotX -= 1f;
                    this.cameraPositionChanged();
                    break;
                case Keys.A:
                    this.rotY -= 1f;
                    this.cameraPositionChanged();
                    break;
                case Keys.D:
                    this.rotY += 1f;
                    this.cameraPositionChanged();
                    break;
                default:
                    break;
            }
            if (e.KeyCode == Keys.Return)
            {
            }
        }

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.
            Z += e.Delta / 120;
        }

    }
}
