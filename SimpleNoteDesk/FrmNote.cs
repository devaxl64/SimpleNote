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
        private int NoteId { get; set; }
        private int UserId { get; set; }
        private int ColorId { get; set; }
        private string Textt { get; set; }
        private string Title { get; set; }
        private int NoteFlag { get; set; }
        public event Action ClickedInSave;



        public FrmNote() // Evento new note
        {
            InitializeComponent();
            this.UserId = Program.LoggedUser.Id; // clnUserNote
            this.ColorId = 1;
            this.NoteFlag = 1; // Noteflag = 1 (New Note)
        }
        public FrmNote(int id, string title, string textt) // Evento Open Note
        {
            InitializeComponent();
            this.NoteId = id; // clnIdNote
            this.UserId = Program.LoggedUser.Id;  // clnUserNote
            this.ColorId = 1; // clnColorNote
            this.Textt = textt; // clnTextNote
            this.Title = title; // clnTitleNote
            this.NoteFlag = 0; // Noteflag = 0 (Open Note)

            txtNote.Text = textt; // clnTextNote
        }


        private void FrmNote_Load(object sender, EventArgs e) 
        {
            // User Information:
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
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Você precisa estar logado para continuar.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            // Configuração do Formulário:
            txtNote.Focus();

            //FrmNote frmNote = new FrmNote(id, userId, colorId, title, textt);
            //frmMain.dgvNotes.

            //);
        }

        public bool SaveNote()
        {
            var notesaved = false;

            var frmMain = new FrmMain();
            SimpleNote note = new SimpleNote();
            note.User.Id = this.UserId;
            note.Color.Id = this.ColorId;
            note.Textt = txtNote.Text;
            note.Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text;


            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Não foi possível salvar...", "Erro com o salvamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                frmMain.ShowSave("NÃO salvo", 5000);

                return notesaved;
            }
            else
            {
                //// DEBUG:
                //MessageBox.Show($"UserId atual: {Program.LoggedUser.Id}");
                //MessageBox.Show($"Texto: '{txtNote.Text}'", "DEBUG");

                //MessageBox.Show($"Titulo: '{note.Title}'", "DEBUG");
                //MessageBox.Show($"Id cor: '{note.Color.Id}'", "DEBUG");
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
            note.Id = this.NoteId;
            note.User.Id = Program.LoggedUser.Id;
            note.Color.Id = 1;
            note.Textt = txtNote.Text; 
            note.Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text;

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Não foi possível atualizar, texto em branco!", "Erro com o salvamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmMain.ShowSave("NÃO Atualizado", 2000);

                // DEBUG:
                //MessageBox.Show($"UserId atual: {Program.LoggedUser.Id}");
                //MessageBox.Show($"Texto: '{txtNote.Text}'", "DEBUG");
            }
            else
            {
                note.UpdateNote();
                frmMain.ShowSave("Atualizado", 2000);
            }
        }

        public void UpdateOrSaveNote()
        {
            if (NoteFlag == 1) // New Note or Open Note
            {
                SaveNote();
            }
            else
            {
                UpdateNote();
            }
            ClickedInSave?.Invoke(); // Recarregar o Grid no FrmMain
        }

        // Botão Salvar / Voltar:
        private void btnRetrun_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Forçar atualização do txtNote.
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
