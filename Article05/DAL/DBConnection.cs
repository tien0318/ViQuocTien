﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article05.DAL
{
  public class DBConnection
    {
        public DBConnection(){
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS; Initial Catalog=sale; User Id=sa;Password=12345";
            return conn;
        }
    }

}

