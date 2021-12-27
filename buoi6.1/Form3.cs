using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi6._1
{
    public partial class Form3 : Form
    {
        PictureBox pb = new PictureBox();
        Timer tmGame = new Timer();
        int xBall = 0;
        int yBall = 0;
        int xDelta = 5;
        int yDelta = 5;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tmGame.Interval = 10;
            tmGame.Tick += tmGame_Tick;
            tmGame.Start();

            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(100, 100);
            this.Controls.Add(pb);
            pb.ImageLocation = @"d:\D:\hinh anh\hinh-tron.jpg";
        }

      

        private void tmGame_Tick(object sender, EventArgs e)
        {
            xBall += xDelta;
            yBall += yDelta;
            if (xBall > this.ClientSize.Width - pb.Width || xBall <= 0)
                xDelta = -xDelta;
            if (yBall > this.ClientSize.Height - pb.Height || yBall <= 0)
                yDelta = -yDelta;
            pb.Location = new Point(xBall, yBall);
        }
    }
}
