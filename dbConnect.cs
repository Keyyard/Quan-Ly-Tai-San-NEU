using System;
using System.Data.SqlClient;

namespace Quan_Ly_Tai_San
{
    public static class dbConnect
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=v;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}