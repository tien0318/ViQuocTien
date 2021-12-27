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
    public partial class Form2 : Form
    {
        int rowindex = -1;
        List<Sinhvien> listSinhVien { get; set; }
        public Form2()
        {
            //listSinhVien = GetSinhVien();

            InitializeComponent();
        }

        //private List<Sinhvien> GetSinhVien()
        //{
        //    List<Sinhvien> lstSinhVien = new List<Sinhvien>();
        //    Sinhvien objSinhVien = new Sinhvien();
        //    objSinhVien.MaSV = "01";
        //    objSinhVien.Hoten = "Nguyen Van A";
        //    objSinhVien.NgaySinh = DateTime.Now;
        //    objSinhVien.NoiSinh = "HCM";
        //    objSinhVien.GioiTinh = true;
        //    lstSinhVien.Add(objSinhVien);

        //    Sinhvien objSinhVien2 = new Sinhvien();
        //    objSinhVien2.MaSV = "02";
        //    objSinhVien2.Hoten = "Nguyen Van B";
        //    objSinhVien2.NgaySinh = DateTime.Now;
        //    objSinhVien2.NoiSinh = "HaNoi";
        //    objSinhVien2.GioiTinh = true;
        //    lstSinhVien.Add(objSinhVien2);

        //    Sinhvien objSinhVien3 = new Sinhvien();
        //    objSinhVien3.MaSV = "03";
        //    objSinhVien3.Hoten = "Nguyen Van C";
        //    objSinhVien3.NgaySinh = DateTime.Now;
        //    objSinhVien3.NoiSinh = "DaNang";
        //    objSinhVien3.GioiTinh = true;
        //    lstSinhVien.Add(objSinhVien3);

        //    return lstSinhVien;
        //}

        private void Form2_Load(object sender, EventArgs e)
                {
                    var sv = this.listSinhVien;
                    dataGridView1.DataSource = sv;
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    var objSV = dataGridView1.SelectedRows[0].DataBoundItem as Sinhvien;
            //    txtmasv.Text = objSV.MaSV.ToString();
            //    txthoten.Text = objSV.Hoten.ToString();
            //    dtngaysinh.Value = objSV.NgaySinh;
            //    txtnoisinh.Text = objSV.NoiSinh.ToString();
            //    chbgioitinh.Checked = objSV.GioiTinh;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            try
            {
                rowindex = e.RowIndex; //Hàng chọn
                if (rowindex != -1 && rowindex < dataGridView1.Rows.Count - 1)
                {
                    txtmasv.Text = dataGridView1.Rows[rowindex].Cells["MaSV"].Value.ToString();
                    txthoten.Text = dataGridView1.Rows[rowindex].Cells["HoTen"].Value.ToString();
                    chbgioitinh.Text = dataGridView1.Rows[rowindex].Cells["GioiTinh"].Value.ToString();
                    txtnoisinh.Text = dataGridView1.Rows[rowindex].Cells["NoiSinh"].Value.ToString();
                    dtngaysinh.Value = DateTime.Parse(dataGridView1.Rows[rowindex].Cells["NamSinh"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtmasv.Text;
            string hoten = txthoten.Text;
            string noisinh = txtnoisinh.Text;
            bool gioitinh = chbgioitinh.Checked;
            DateTime ngaysinh = dtngaysinh.Value;
            int row = dataGridView1.Rows.Add();//Thêm mới 1 hàng


            //Đưa dữ liệu lên lưới
            dataGridView1.Rows[row].Cells["HoTen"].Value = hoten;
            dataGridView1.Rows[row].Cells["MaSV"].Value = ma;
            dataGridView1.Rows[row].Cells["GioiTinh"].Value = gioitinh;
            dataGridView1.Rows[row].Cells["NamSinh"].Value = ngaysinh;
            dataGridView1.Rows[row].Cells["NoiSinh"].Value = noisinh;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ma = txtmasv.Text;
            string hoten = txthoten.Text;
            string noisinh = txtnoisinh.Text;
            bool gioitinh = chbgioitinh.Checked;
            DateTime ngaysinh = dtngaysinh.Value;
 
            //Đưa dữ liệu lên lưới
            dataGridView1.Rows[rowindex].Cells["MaSV"].Value = ma;
            dataGridView1.Rows[rowindex].Cells["HoTen"].Value = hoten;
            dataGridView1.Rows[rowindex].Cells["GioiTinh"].Value = gioitinh;
            dataGridView1.Rows[rowindex].Cells["NamSinh"].Value = ngaysinh;
            dataGridView1.Rows[rowindex].Cells["NoiSinh"].Value = noisinh;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra sinh viên
                if (rowindex == -1 || rowindex >= dataGridView1.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn sinh viên cần xóa");
                }
                dataGridView1.Rows.RemoveAt(rowindex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát không",
  
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if(result==DialogResult.Yes)
                {
                Application.Exit();

            }
        }
    }
}
