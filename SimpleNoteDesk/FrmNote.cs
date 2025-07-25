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


        public FrmNote() // Evento new note
        {
            InitializeComponent();

        }
        public FrmNote(int id, string title, string textt) // Evento Open Note
        {
            var user = Program.LoggedUser.Id;
            var note = new SimpleNote();
            this.ColorId = 1;
            NoteColor color = NoteColor.GetById(ColorId);
            note.Id = user;
            note.Color = color;

            InitializeComponent();
            this.NoteId = id;
            this.UserId = user;
            txtNote.Text = textt; // clnTextNote
            title = textt.Length > 40 ? textt.Substring(0, 40) : textt; // clnTitleNote
            this.Title = title;
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
            var frmNote = new FrmNote();
            var frmMain = new FrmMain();
            //SimpleNote note = new SimpleNote();
            //note.Id = this.NoteId;
            //note.User.Id = this.UserId;
            //note.Color.Id = this.ColorId;
            //note.Textt = txtNote.Text; // clnTextNote
            //note.Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text; // 

            var user = Program.LoggedUser.Id;
            var note = new SimpleNote();
            int id;

            this.ColorId = 1;
            NoteColor color = NoteColor.GetById(ColorId);
            note.Id = user;
            note.Color = color;

            InitializeComponent();
            this.NoteId = id;
            this.UserId = user;
            txtNote.Text = textt; // clnTextNote
            title = textt.Length > 40 ? textt.Substring(0, 40) : textt; // clnTitleNote
            this.Title = title;

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
