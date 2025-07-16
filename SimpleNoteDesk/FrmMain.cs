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
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.ShowDialog();
            this.dgvNotes.Hide();
            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
            this.Show();
            LoadGridNotes();
        }

        private void LoadGridNotes()
        {
            var notes = SimpleNote.GetList();
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNote frmNote = new FrmNote();
            frmNote.ShowDialog();
        }
    }
}
