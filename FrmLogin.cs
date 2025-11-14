namespace Quan_Ly_Tai_San
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy flop = new FrmDangKy();
            flop.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
