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
    public partial class Form4 : Form
    {
        PictureBox pbEgg = new PictureBox();
        Timer tmEgg = new Timer();
        int xEgg = 300;
        int yEgg = 0;
        int xDelta = 3;
        int yDelta = 3;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(100, 100);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);
            //pbEgg.Image = Image.FromFile("");
            //pbEgg.ImageLocation = @"d:\D:\hinhanh\th1.jpg";
            pbEgg.ImageLocation = @"D:\hinh anh\914193b877b617ca7555473a047ece31.jpg";

        }

        private void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
                //pbEgg.Image = Image.FromFile ("");
            //pbEgg.ImageLocation = @"d:\D:\hinhanh\th2.jpg";
            pbEgg.ImageLocation = @"D:\hinh anh\914193b877b617ca7555473a047ece31.jpg";
            pbEgg.Location = new Point(xEgg, yEgg);

        }
    }
}
