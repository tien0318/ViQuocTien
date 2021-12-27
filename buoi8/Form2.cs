using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace buoi8
{
    public partial class Form2 : Form
    {
        private int idx;
        private int index;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS; Initial Catalog=sale; User Id=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    dgvEmployee.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            conn.Close();
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into Customer values(" + tbId.Text+",'" + tbName.Text + "')", conn);
           
            cmd.ExecuteNonQuery();
            conn.Close();

            dgvEmployee.Rows.Add(tbId.Text, tbName.Text);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where id=" + tbId.Text, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvEmployee.CurrentCell.RowIndex;
            dgvEmployee.Rows.RemoveAt(index);
        }

     

        private void btExit_Click(object sender, EventArgs e)
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

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customer set Name='" + tbName.Text+ "'  where id=" + tbId.Text, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            int idx = dgvEmployee.CurrentCell.RowIndex;
            dgvEmployee.Rows[idx].Cells[1].Value = tbName.Text;

        }
    }
}
