namespace Tetris
{
    partial class debug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consol = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // consol
            // 
            this.consol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consol.Location = new System.Drawing.Point(-1, -3);
            this.consol.Name = "consol";
            this.consol.Size = new System.Drawing.Size(287, 265);
            this.consol.TabIndex = 0;
            this.consol.Text = "";
            // 
            // debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.consol);
            this.Name = "debug";
            this.Text = "debug";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox consol;
    }
}