﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class debug : Form
    {
        public debug()
        {
            InitializeComponent();
        }
        public void putConsoleText(string text)
        {
            consol.Text = text + "\n" + consol.Text;
        }
    }
}
