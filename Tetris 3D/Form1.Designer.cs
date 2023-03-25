namespace Tetris
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Automatically created by Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnT.Location = new System.Drawing.Point(0, 0);
            this.AnT.Margin = new System.Windows.Forms.Padding(0);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(725, 431);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFS_KeyDown);
            this.AnT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormFS_KeyUp);
            this.AnT.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            this.AnT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AnT_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 431);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.form1sizechanged);
            this.ResumeLayout(false);
            // 
            // refreshtimer
            // 
            this.refreshtimer = new System.Windows.Forms.Timer(this.components);
            this.refreshtimer.Interval = 10;
            this.refreshtimer.Tick += new System.EventHandler(this.refreshtimer_Tick);
        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer refreshtimer;
    }
}

