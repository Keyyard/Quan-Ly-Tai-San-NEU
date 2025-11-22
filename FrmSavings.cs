using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmSavings : Form
    {
        private int selectedCategoryId = -1;

        public FrmSavings()
        {
            InitializeComponent();
            LoadSavings();
        }

        private void LoadSavings()
        {
            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetSavingsGoals", parameters);
                dataSavings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tiết kiệm: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) // Using as Add
        {
            string name = txtName.Text.Trim();
            decimal goal;
            if (string.IsNullOrEmpty(name) || !decimal.TryParse(txtGoal.Text, out goal) || goal <= 0)
            {
                MessageBox.Show("Vui lòng nhập tên và mục tiêu hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@GoalAmount", goal),
                    new SqlParameter("@Description", DBNull.Value)
                };
                db.ThucThi_Proc("sp_InsertSavingsGoal", parameters);

                MessageBox.Show("Tiết kiệm đã được tạo.");
                LoadSavings();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo tiết kiệm: " + ex.Message);
            }
        }

        private void dataSavings_SelectionChanged(object sender, EventArgs e)
        {
            if (dataSavings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataSavings.SelectedRows[0];
                selectedCategoryId = (int)row.Cells["GoalId"].Value;
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtGoal.Text = row.Cells["GoalAmount"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để chỉnh sửa.");
                return;
            }

            string name = txtName.Text.Trim();
            decimal goal;
            if (string.IsNullOrEmpty(name) || !decimal.TryParse(txtGoal.Text, out goal))
            {
                MessageBox.Show("Dữ liệu không hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@GoalId", selectedCategoryId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@GoalAmount", goal)
                };
                db.ThucThi_Proc("sp_UpdateSavingsGoal", parameters);

                MessageBox.Show("Tiết kiệm đã được cập nhật.");
                LoadSavings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tiết kiệm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                try
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@GoalId", selectedCategoryId)
                    };
                    db.ThucThi_Proc("sp_DeleteSavingsGoal", parameters);

                    MessageBox.Show("Tiết kiệm đã được xóa.");
                    LoadSavings();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            selectedCategoryId = -1;
            txtName.Text = "";
            txtGoal.Text = "";
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để gửi tiền.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số tiền gửi:", "Deposit", "0");
            if (!decimal.TryParse(input, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                // Insert transaction - trigger will handle balance and goal updates
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@CategoryId", selectedCategoryId),
                    new SqlParameter("@Amount", amount),
                    new SqlParameter("@Description", "Deposit to savings")
                };
                db.ThucThi_Proc("sp_InsertSavingTransaction", parameters);

                MessageBox.Show("Đã gửi tiền vào tiết kiệm.");
                LoadSavings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tiền: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
