using Cau1.BAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class CongNoGUI : Form
    {
        CongNoBAL cnBAL = new CongNoBAL();
        public CongNoGUI()
        {
            InitializeComponent();
        }

        private void CongNoGUI_Load(object sender, EventArgs e)
        {
            List<CongNoDTO> lstCongNo = cnBAL.ReadCongNo();
            foreach (CongNoDTO cn in lstCongNo)
            {
                dgvCongNo.Rows.Add(cn.MaKH, cn.TenKH, cn.Sdt, cn.STno);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();

            if (tbId.Text.Equals("") || tbName.Text.Equals("") || tbSdt.Text.Equals("") || tbSotienno.Text.Equals(""))
            {
                MessageBox.Show("Không đc bỏ trống", "Thông báo");
            }
            else
            {
                cn.STno = decimal.Parse(tbSotienno.Text);
                cn.MaKH = tbId.Text;
                cn.TenKH = tbName.Text;
                cn.Sdt = tbSdt.Text;
                cnBAL.ThemCongNo(cn);

                dgvCongNo.Rows.Add(cn.MaKH, cn.TenKH, cn.Sdt, cn.STno);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();

            if (tbId.Text.Equals("") || tbName.Text.Equals("") || tbSdt.Text.Equals("") || tbSotienno.Text.Equals(""))
            {
                MessageBox.Show("Không đc bỏ trống", "Thông báo");
            }
            else
            {
                cn.STno = decimal.Parse(tbSotienno.Text);
                cn.MaKH = tbId.Text;
                cn.TenKH = tbName.Text;
                cn.Sdt = tbSdt.Text;
                cnBAL.SuaCongNo(cn);
                DataGridViewRow row = dgvCongNo.CurrentRow;
                row.Cells[0].Value = cn.MaKH;
                row.Cells[1].Value = cn.TenKH;
                row.Cells[2].Value = cn.Sdt;
                row.Cells[3].Value = cn.STno;

            }
        }

        private void dgvCongNo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCongNo.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbSdt.Text = row.Cells[2].Value.ToString();
            }
            tbSotienno.Text = row.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();
            cn.STno = decimal.Parse(tbSotienno.Text);
            cn.MaKH = tbId.Text;
            cn.TenKH = tbName.Text;
            cn.Sdt = tbSdt.Text;
            int idx = dgvCongNo.CurrentCell.RowIndex;
            cnBAL.XoaCongNo(cn);
            dgvCongNo.Rows.RemoveAt(idx);
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
