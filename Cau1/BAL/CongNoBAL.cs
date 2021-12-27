using Cau1.DAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    class CongNoBAL:CongNoDAL
    {
        CongNoDAL dal = new CongNoDAL();
        public List<CongNoDTO> ReadCongNo()
        {
            List<CongNoDTO> lstCus = dal.ReadCongNo();
            return lstCus;
        }
        public void ThemCongNo(CongNoDTO cn)
        {
            dal.ThemCongNo(cn);
        }
        public void XoaCongNo(CongNoDTO cn)
        {
            dal.XoaCongNo(cn);
        }
        public void SuaCongNo(CongNoDTO cn)
        {
            dal.SuaCongNo(cn);
        }
    }
}
