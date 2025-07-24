using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using Aspose.Pdf.Operators;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Utilities;
using SimpleNoteClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNoteDesk
{
    public partial class FrmNote : Form
    {
        public FrmNote() // Evento new note
        {
            InitializeComponent();

        }
        public FrmNote(int id, User user, NoteColor color, string title, string textt) // Evento Open Note
        {
            InitializeComponent();
            SimpleNote note = new SimpleNote();

            id = note.Id; // clnIdNote
            user = Program.LoggedUser; ; // clnUserNote
            color = note.Color; // clnColorNote
            title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text; // clnTitleNote
            txtNote.Text = textt; // clnTextNote
        }


        private void FrmNote_Load(object sender, EventArgs e) 
        {
            // User Information:

            FrmLogin frmLogin = new FrmLogin();
            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
            else
            {
                if (Program.LoggedUser.Id < 1)
                {
                    this.Hide();
                    frmLogin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Você precisa estar logado para continuar.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }

            // Configuração do Formulário:
            //FrmNote frmNote = new FrmNote(id, userId, colorId, title, textt);
            //frmMain.dgvNotes.

            //);
        }

        public bool SaveNote()
        {
            var notesaved = false;

            var frmMain = new FrmMain();
            SimpleNote note = new SimpleNote();

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Não foi possível salvar...", "Erro com o salvamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                frmMain.ShowSave("NÃO salvo", 5000);

                return notesaved;
            }
            else
            {

                note.InsertNote();

                notesaved = true;
                frmMain.ShowSave("Salvo", 5000);
            }
            return notesaved;
        }

        public void UpdateNote()
        {
            var frmMain = new FrmMain();
            SimpleNote note = new SimpleNote();

            note.Id = Convert.ToInt32(frmMain.dgvNotes.Rows[0].Cells[0].Value); // clnIdNote
            note.User = Program.LoggedUser; // clnUserNote
            note.Color.Id = 1; // clnColorNote
            note.Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text; // clnTitleNote
            note.Textt = txtNote.Text; // clnTextNote

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Não foi possível atualizar...", "Erro com o salvamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmMain.ShowSave("NÃO Atualizado", 2000);
            }
            else
            {
                note.UpdateNote();
                frmMain.ShowSave("Atualizado", 2000);
            }
        }

        public void UpdateOrSaveNote()
        {
            var frmMain = new FrmMain();
            SimpleNote note = new SimpleNote();
            if (Convert.ToInt32(frmMain.dgvNotes.Rows[0].Cells[0].Value) == note.Id) // clnIdNote
            {
                SaveNote();
            }
            else
            {
                UpdateNote();
            }
        }

        // Botão Salvar / Voltar:
        private void btnRetrun_Click(object sender, EventArgs e)
        {
            UpdateOrSaveNote();
            this.Close();
        }


        // Saves Configuration when the form is closing:
        private void FrmNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateOrSaveNote();
        }
        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateOrSaveNote();
        }

        private void FrmNote_Deactivate(object sender, EventArgs e)
        {
            UpdateOrSaveNote();
        }

        private void FrmNote_Leave(object sender, EventArgs e)
        {
            UpdateOrSaveNote();
        }

    }
}
