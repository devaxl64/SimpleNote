using SimpleNoteClass;

namespace SimpleNoteDesk
{
    public partial class FrmMain : Form
    {
        public object DataGridView { get; internal set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
            else
            {
                if (Program.LoggedUser.Id < 1)
                {
                    FrmLogin frmLogin = new FrmLogin();
                    this.Hide();
                    frmLogin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Você precisa estar logado para continuar.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            this.Show();
            LoadGridNotes();
        }

        public void LoadGridNotes()
        {
            //var notes = SimpleNote.GetListByUser(User.GetById); // Assuming User.GetById returns the
            var notes = SimpleNote.GetList();
            int line = 0;
            dgvNotes.Rows.Clear();
            foreach (var note in notes)
            {
                dgvNotes.Rows.Add();
                dgvNotes.Rows[line].Cells[0].Value = note.Id; // clnIdNote
                dgvNotes.Rows[line].Cells[1].Value = note.User.Id; // clnUserNote
                dgvNotes.Rows[line].Cells[2].Value = note.Color.TypeColor; // clnColorNote
                dgvNotes.Rows[line].Cells[3].Value = note.Title; // clnTitleNote
                dgvNotes.Rows[line].Cells[4].Value = note.Textt; // clnTextNote
                dgvNotes.Rows[line].Cells[5].Value = note.Datte.ToString("dd/MM/yyyy HH:mm:ss"); // clnDateNote
                dgvNotes.Rows[line].Cells[6].Value = note.Archived ? "Yes" : "No"; // clnArchivedNote
                dgvNotes.Rows[line].Cells[7].Value = note.Deleted ? "Yes" : "No"; // clnDeletedNote
                line++;
            }
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            FrmNote frmNote = new FrmNote();
            frmNote.ShowDialog();
            this.Hide();
        }

        // Mensagem temporária:
        public void ShowSave(string message, int duration = 2000)
        {
            lblSave.Text = message;
            lblSave.Visible = true;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = duration; // milissegundos
            timer.Tick += (s, e) =>
            {
                lblSave.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }


        private void dgvNotes_CellContentClick(object sender, DataGridViewCellEventArgs e) // Abrir nota já criada.
        {
            string textt = dgvNotes.Rows[e.RowIndex].Cells[4].Value.ToString();
            FrmNote frmNote = new FrmNote(textt);
            frmNote.ShowDialog();
            //if (frmNote = )
            //{
            this.Hide();
            //}
            //else
            //{
            //    this.ShowDialog();
            //}
        }
    }
}
