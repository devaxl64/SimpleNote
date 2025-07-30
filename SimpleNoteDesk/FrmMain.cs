using SimpleNoteClass;

namespace SimpleNoteDesk
{
    public partial class FrmMain : Form
    {
        private User UserId { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            if (Program.LoggedUser.Id <= 0)
            {
                // User Login:
                this.Hide();
                frmLogin.ShowDialog();

                // User Information:
                if (Program.LoggedUser.Id >= 1)
                {
                    var loggedUser = Program.LoggedUser;
                    this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Você precisa estar logado para continuar.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Você já estava logado.", "Login já ativo:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Show();
            }
            LoadGridNotes();


        }

        public void LoadGridNotes()
        {
            var userId = Program.LoggedUser.Id;

            var notes = SimpleNote.GetListByUser(userId);
            int line = 0;
            dgvNotes.Rows.Clear();
            foreach (var note in notes)
            {
                dgvNotes.Rows.Add();
                dgvNotes.Rows[line].Cells[0].Value = note.Id; // clnIdNote
                dgvNotes.Rows[line].Cells[1].Value = note.User; // clnUserNote
                dgvNotes.Rows[line].Cells[2].Value = note.Color.TypeColor; // clnColorNote
                dgvNotes.Rows[line].Cells[3].Value = note.Title; // clnTitleNote
                dgvNotes.Rows[line].Cells[4].Value = note.Textt; // clnTextNote
                dgvNotes.Rows[line].Cells[5].Value = note.Datte.ToString("dd/MM/yyyy HH:mm:ss"); // clnDateNote
                dgvNotes.Rows[line].Cells[6].Value = note.Archived ? "Yes" : "No"; // clnArchivedNote
                dgvNotes.Rows[line].Cells[7].Value = note.Deleted ? "Yes" : "No"; // clnDeletedNote
                line++;
            }
        }
        private void NewNote()
        {
            // Abrir nova nota:
            FrmNote frmNote = new FrmNote();
            frmNote.ClickedInSave += LoadGridNotes; // Recarregar Grid sempre que fechado as notas
            frmNote.Show();

        }
        private void OpenNote()
        {
            int line = dgvNotes.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dgvNotes.Rows[line].Cells[0].Value);
            string title = dgvNotes.Rows[line].Cells[3].Value.ToString();
            string textt = dgvNotes.Rows[line].Cells[4].Value.ToString();

            FrmNote frmNote = new FrmNote(id, title, textt);

            frmNote.ClickedInSave += LoadGridNotes; // Recarregar Grid sempre que fechado as notas:
            frmNote.Show();
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            NewNote();
        }

        private void dgvNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenNote();
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
    }
}
