using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi2
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        private object lblShowDisplay;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void click_button(object sender, EventArgs e)
        {
            if (txt_display.Text == "0")
            {
                txt_display.Clear();
            }
            isOperationPerformed = false;
            Button btnNumber = (Button)sender;
            txt_display.Text += btnNumber.Text;
        }

      

        private void click_operator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = Double.Parse(txt_display.Text);
            txt_display.Text = "";
            labelCurrentOperation.Text = resultValue + "" + operationPerformed;
            isOperationPerformed = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    txt_display.Text=(resultValue + Double.Parse(txt_display.Text)).ToString();
                    break;
                case "-":
                    txt_display.Text = (resultValue - Double.Parse(txt_display.Text)).ToString();
                    break;
                case "×":
                    txt_display.Text = (resultValue * Double.Parse(txt_display.Text)).ToString();
                    break;
                case "÷":
                    txt_display.Text = (resultValue / Double.Parse(txt_display.Text)).ToString();
                    break;
                
                default:
                    break;
            }
            resultValue = Double.Parse(txt_display.Text);
            labelCurrentOperation.Text = "";
        }

        
        
        private void CE_Click(object sender, EventArgs e)
         {
              txt_display.Text = "0";
              resultValue = 0;
          }

        private void C_Click(object sender, EventArgs e)
        {
            txt_display.Text = "0";
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txt_display.Text = "0";
        }

       
    }
}
