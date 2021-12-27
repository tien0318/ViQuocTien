﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi6
{
    public partial class Form1 : Form
    {
        PictureBox pb = new PictureBox();
        int x = 0;
        int y = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x -= 10;
            pb.Location = new Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x += 10;
            pb.Location = new Point(x, y);
        }

        private void btFile(object sender, EventArgs e)
        {
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(100, 100);
            pb.Location = new Point(x, y);
            this.Controls.Add(pb);
            pb.ImageLocation = @"D:\hinh anh\914193b877b617ca7555473a047ece31.jpg";
        }
    }
}
