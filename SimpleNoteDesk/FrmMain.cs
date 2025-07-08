namespace SimpleNoteDesk
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.   Hide();
            frmLogin.ShowDialog();
            //if (Program.UsuarioLogado.Id > 0)
            //{
            //    tsslUsuarioLogado.Text = $"{Program.UsuarioLogado.Nome} - {Program.UsuarioLogado.Nivel.Nome}";
            //}
            this.Show();
        }
    }
}
