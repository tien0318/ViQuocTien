using Article06;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi9
{
    public partial class CustomerGUI : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        public CustomerGUI()
        {
            InitializeComponent();
        }

        private void CustomerGUI_Load(object sender, EventArgs e)
        {
            {
                List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
                foreach (CustomerBEL cus in lstCus)
                {
                    dgvCustomer.Rows.Add(cus.Id, cus.Name);
                }
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(tbId.Text);
                cus.Name = tbName.Text;
                cusBAL.NewCustomer(cus);
                dgvCustomer.Rows.Add(cus.Id, cus.Name);
            

        }

        private void btxDelete_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.DeleteCustomer(cus);
            int index = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows.RemoveAt(index);
        }

        private void btxEdit_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.EditCustomer(cus);
            int index = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows[index].Cells[1].Value = tbName.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
          "Bạn có chắc muốn thoát không",

          "Thông báo",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

  
    }
}
