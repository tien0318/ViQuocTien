using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 bai1 = new Form1();
            bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 bai2 = new Form2();
            bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 bai3 = new Form3();
            bai3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 bai4 = new Form4();
            bai4.Show();
        }
    }
}
