using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmSignIn : Form
    {
        public static int CurrentUserId { get; private set; }
        public static string CurrentUsername { get; private set; }

        public FrmSignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };
                
                DataTable result = db.Lay_Dulieu_Proc("sp_UserLogin", parameters);
                
                if (result.Rows.Count > 0)
                {
                    CurrentUserId = (int)result.Rows[0]["UserId"];
                    CurrentUsername = result.Rows[0]["Username"].ToString();
                    this.Hide();
                    FrmDashboard mainForm = new FrmDashboard();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FrmSignUp signupForm = new FrmSignUp();
            signupForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
