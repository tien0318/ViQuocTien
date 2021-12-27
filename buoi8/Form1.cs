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
    public partial class Form1 : Form
    {
        //string str = @"Data Source = ADMIN\SQLEXPRESS; Initial Catalog = vql1; Integrated Security = True";
      
        public Form1()
        {
            InitializeComponent();
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Customer values(5,'Nguyen Van X')";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    
    

        private void btDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS; Initial Catalog=sale; User Id=sa;Password=12345";
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customer where id = 5", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";
            conn.Open();
 
            SqlCommand cmd = new SqlCommand("update  Customer set Name='Nguyen Van b' where id=2", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void btRead_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=sale; User ID=sa;Password=12345";

        
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

        private void button5_Click(object sender, EventArgs e)
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
