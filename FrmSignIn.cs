namespace Quan_Ly_Tai_San
{
    public partial class FrmSignIn : Form
    {
        public FrmSignIn()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmSignUp flop = new FrmSignUp();
            flop.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
