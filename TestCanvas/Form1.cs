namespace TestCanvas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color black = Color.FromArgb(255, 0, 0, 0);
            Pen blackPen = new Pen(black);
            e.Graphics.DrawLine(blackPen, 300, 200, 800, 200);
            blackPen.Width = 20;
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            blackPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            e.Graphics.DrawLine(blackPen, 300, 200, 800, 200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}