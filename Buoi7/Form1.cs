using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi7
{
    public partial class Form1 : Form
    {
        PictureBox pbBasket = new PictureBox();
        PictureBox pbEgg = new PictureBox();
        PictureBox pbChicken = new PictureBox();
        Timer tmEgg = new Timer();
        Timer tmChicken = new Timer();
        Timer tmEggEnd = new Timer();
        int dem = 0;


        int xBasket = 100;
        int yBasket = 150;
        int xDeltaBasket = 30;

        int xChicken = 100;
        int yChicken = 10;
        int xDeltaChicken = 5;

        int xEgg = 100;
        int yEgg = 10;
        int yDeltaEgg = 3;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmEgg.Interval = 1;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            tmEggEnd.Interval = 50;
            tmEggEnd.Tick += tmEggEnd_Tick;

            tmChicken.Interval = 5;
            tmChicken.Tick += tmChicken_Tick;
            tmChicken.Start();

            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(70, 70);
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.Transparent;
            this.Controls.Add(pbBasket);
            //pbBasket.Image = Image.FromFile(".../.../Buoi7/Img/caigio.jpg");
            pbBasket.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\caigio.jpg";

            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 50);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);
            //pbEgg.Image = Image.FromFile(".../.../Buoi7/Img/th1.jpg");
            pbEgg.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\th1.jpg";


            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.Size = new Size(50, 50);
            pbChicken.Location = new Point(xChicken, yChicken);
            pbChicken.BackColor = Color.Transparent;
            this.Controls.Add(pbChicken);
            //pbChicken.Image = Image.FromFile(".../.../Buoi7/Img/convit.jpg");
            pbChicken.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\convit.jpg";


        }
        private void tmEggEnd_Tick(object sender, EventArgs e)
        {
            yEgg = 30;
            xEgg = pbChicken.Location.X;

            pbEgg.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\th1.jpg";
            tmEgg.Start();
            tmEggEnd.Stop();
        }
        private void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
            {
                tmEgg.Stop();
                tmEggEnd.Start();
                pbEgg.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\th2.jpg";

            }
            Rectangle unionRect = Rectangle.Intersect(pbEgg.Bounds, pbBasket.Bounds);
            if (unionRect.IsEmpty == false)
            {
                tmEgg.Stop();
                tmEggEnd.Start();
                pbEgg.ImageLocation = @"D:\hoctap_hk5\C#\C#\ViQuocTien\Buoi7\Img\th1.jpg";
                dem++;
                label1.Text = "Điểm:" + dem.ToString();
            }
            
            pbEgg.Location = new Point(xEgg, yEgg);
                
        }


        private void tmChicken_Tick(object sender, EventArgs e)
        {
            xChicken += xDeltaChicken;
            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
                xDeltaChicken = -xDeltaChicken;
            pbChicken.Location = new Point(xChicken, yChicken);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 39 & (xBasket < this.ClientSize.Width - pbBasket.Width))
                xBasket += xDeltaBasket;
            if (e.KeyValue == 37 & xBasket > 0)
                xBasket -= xDeltaBasket;
            pbBasket.Location = new Point(xBasket, yBasket);
        }

        
    }
}
