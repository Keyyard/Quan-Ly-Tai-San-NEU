using System;
using System.Data.SqlClient;

namespace Quan_Ly_Tai_San
{
    public static class DBHelper
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=FinanceTrackerDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}