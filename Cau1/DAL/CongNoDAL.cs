using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    class CongNoDAL:DBConnection
    {
        public List<CongNoDTO> ReadCongNo()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CongNo", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CongNoDTO> lstCongNo = new List<CongNoDTO>();

            while (reader.Read())
            {
                CongNoDTO objCongNoDTO = new CongNoDTO();
                objCongNoDTO.MaKH = reader["MaKH"].ToString();
                objCongNoDTO.TenKH = reader["TenKH"].ToString();
                objCongNoDTO.Sdt = reader["Sdt"].ToString();
                objCongNoDTO.STno = decimal.Parse(reader["STno"].ToString());

                lstCongNo.Add(objCongNoDTO);
            }
            conn.Close();
            return lstCongNo;
        }

        public void XoaCongNo(CongNoDTO cn)
        {
            //SqlConnection conn = CreateConnection();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("SP_Delete", conn);

            //cmd.Parameters.Add(new SqlParameter("@makh", cn.MaKH));
            //cmd.ExecuteNonQuery();
            //conn.Close();


            //sử dụng lớp SqlConnection để tạo chuỗi kết nối
            SqlConnection conn = CreateConnection();
            conn.Open();
            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand SqlCmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                SqlCmd.CommandText = "SP_Delete";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                SqlCmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = cn.MaKH;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                SqlCmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }

        }
        public void SuaCongNo(CongNoDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //SqlCommand cmd = new SqlCommand(
            //    "insert into CongNo values(@makh,@tenkh,@sdt,@stno)", conn);

            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand SqlCmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                SqlCmd.CommandText = " SP_Sua";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                SqlCmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = cn.MaKH;
                SqlCmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = cn.TenKH;
                SqlCmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = cn.Sdt;
                SqlCmd.Parameters.Add("@SoTien", SqlDbType.Decimal).Value = cn.STno;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                SqlCmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Sua thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }


            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = connection;
            //cmd.CommandText = "Select_tudent";
            //cmd.CommandType = CommandType.StoredProcedure;


            //cmd.Parameters.Add(new SqlParameter("@makh", cn.MaKH));
            //cmd.Parameters.Add(new SqlParameter("@tenkh", cn.TenKH));
            //cmd.Parameters.Add(new SqlParameter("@sdt", cn.Sdt));
            //cmd.Parameters.Add(new SqlParameter("@stno", cn.STno));
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }
        public void ThemCongNo(CongNoDTO cn)
        {
            SqlConnection con = CreateConnection();
            con.Open();
            ////SqlCommand cmd = new SqlCommand(
            ////    "update CongNo set makh = @makh, tenkh = @tenkh, sdt = @sdt where @makh = makh", conn);
            //SqlCommand cmd = new SqlCommand("SP_Update", conn);
            //cmd.Parameters.Add(new SqlParameter("@makh", cn.MaKH));
            //cmd.Parameters.Add(new SqlParameter("@tenkh", cn.TenKH));
            //cmd.Parameters.Add(new SqlParameter("@sdt", cn.Sdt));
            //cmd.Parameters.Add(new SqlParameter("@stno", cn.STno));
            //cmd.ExecuteNonQuery();
            //conn.Close();

            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "spInsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = cn.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = cn.TenKH;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = cn.Sdt;
                cmd.Parameters.Add("@SoTien", SqlDbType.Decimal).Value = cn.STno;
                //mở chuỗi kết nối
                con.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                con.Close();

                Console.WriteLine("Them thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }

        }
    }
}
