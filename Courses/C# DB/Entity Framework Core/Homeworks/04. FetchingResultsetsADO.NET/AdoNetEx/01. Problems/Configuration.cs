using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetEx
{
    public static class Configuration
    {
        // 00.01. Problem
        //public const string ConnectionString = @"Server=DESKTOP-TU655AE\SQLEXPRESS;;Integrated Security=True";

        // 00.02. Problem
        public const string ConnectionString = @"Server=DESKTOP-TU655AE\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";
    }
}
