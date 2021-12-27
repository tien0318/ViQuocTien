using System.Windows.Forms;

namespace Article06
{
    internal class CustomerGUI : Form
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomerGUI
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "CustomerGUI";
            this.Load += new System.EventHandler(this.CustomerGUI_Load);
            this.ResumeLayout(false);

        }

        private void CustomerGUI_Load(object sender, System.EventArgs e)
        {

        }
    }
}