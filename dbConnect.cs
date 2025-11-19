using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Tai_San
{
    internal class dbConnect
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void KetNoi_Dulieu()
        {
            string sql1 = @"Data Source=tmh\SQLEXPRESS;Initial Catalog=financeTrackerdb;Integrated Security=True;TrustServerCertificate=True";
            cnn = new SqlConnection(sql1);
            cnn.Open();
        }

        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }

        public DataTable Lay_Dulieubang(string Sql, SqlParameter[] parameters = null)
        {
            KetNoi_Dulieu();
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }

        public void ThucThi(string Sql)
        {
            KetNoi_Dulieu();
            cmd = new SqlCommand(Sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }

        public DataTable Lay_Dulieu_Proc(string procName, SqlParameter[] parameters)
        {
            KetNoi_Dulieu();
            cmd = new SqlCommand(procName, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            ada = new SqlDataAdapter(cmd);
            dta = new DataTable();
            ada.Fill(dta);
            HuyKetNoi();
            return dta;
        }

        public void ThucThi_Proc(string procName, SqlParameter[] parameters)
        {
            KetNoi_Dulieu();
            cmd = new SqlCommand(procName, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}