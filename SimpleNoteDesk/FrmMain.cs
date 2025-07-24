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

            // Recarregar Grid sempre que fachado as notas:
            FrmNote frmNote = new FrmNote();
            frmNote.FormClosed += (sender, args) => LoadGridNotes();
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

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNote frmNote = new FrmNote();

            frmNote.FormClosed += (sender, args) => this.Show();

            frmNote.Show();
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
            int line = dgvNotes.CurrentCell.RowIndex;
            
            var noteLine = Convert.ToInt32(dgvNotes.Rows[line].Cells[0].Value);
            var noteInfoId = SimpleNote.GetById(noteLine);
            var userLine = Convert.ToInt32(dgvNotes.Rows[line].Cells[1].Value);
            var user = User.GetById(userLine); // mesmo nome da classe pertencente
            var colorLine = Convert.ToInt32(dgvNotes.Rows[line].Cells[2].Value);
            var color = NoteColor.GetById(colorLine); // mesmo nome da classe pertencente

            int id = noteInfoId.Id;
            string title = noteInfoId.Title;
            string textt = noteInfoId.Textt;
            
            FrmNote frmNote = new FrmNote(id, user, color, title, textt);
            frmNote.ShowDialog();
        }
    }
}
