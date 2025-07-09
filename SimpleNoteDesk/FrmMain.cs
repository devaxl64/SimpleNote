using SimpleNoteClass;

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
            //LoadGridNotes();
            LoadGridLevels();
            this.dgvNotes.Hide();
            //FrmLogin frmLogin = new FrmLogin();
            //this.Hide();
            //frmLogin.ShowDialog();
            ////if (Program.UsuarioLogado.Id > 0)
            ////{
            ////    tsslUsuarioLogado.Text = $"{Program.UsuarioLogado.Nome} - {Program.UsuarioLogado.Nivel.Nome}";
            ////}
            //this.Show();
        }
        private void LoadGridNotes()
        {
            //var notes = Note.GetList();
        }
        private void LoadGridLevels()
        {
            var levels = Level.GetList();
            int line = 0;
            //dgvLevels.Rows.Clear();
            foreach (var level in levels)
            {
                dgvLevels.Rows.Add();
                dgvLevels.Rows[line].Cells[0].Value = level.Id; // clnIdLevel
                dgvLevels.Rows[line].Cells[1].Value = level.Name; // clnNameLevel
                dgvLevels.Rows[line].Cells[2].Value = level.Aka; // clnAkaLevel
                line++;
            }

        }
    }
}
