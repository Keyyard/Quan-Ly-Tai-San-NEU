using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                resultParam.Direction = ParameterDirection.Output;
                
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password),
                    resultParam
                };
                
                db.ThucThi_Proc("sp_UserRegister", parameters);
                
                int result = (int)resultParam.Value;
                if (result == -1)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
