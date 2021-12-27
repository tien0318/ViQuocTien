using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi8
{
    public partial class Form3 : Form
    {
        private object dgvEmployee;
        private int index;

        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS; Initial Catalog=sale; User Id=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dgvCustomer.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            conn.Close();
        }

        private void btNew(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into Customer values(@id,@name)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", tbName.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            dgvCustomer.Rows.Add(tbId.Text, tbName.Text);
        }

        private void btDelete(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows.RemoveAt(idx);
        }

        private void btEdit(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customer set Name=@name where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", tbName.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows[idx].Cells[1].Value = tbName.Text;


        }

        private void btExit(object sender, EventArgs e)
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
            tbId.Text = dgvCustomer.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvCustomer.Rows[idx].Cells[1].Value.ToString();
        }
    }
}
