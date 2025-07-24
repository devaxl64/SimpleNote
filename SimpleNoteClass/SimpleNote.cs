using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    public class SimpleNote
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public NoteColor? Color { get; set; }
        public  string? Title { get; set; }
        public string? Textt { get; set; }
        public DateTime Datte { get; set; }
        public bool Archived { get; set; }
        public bool Deleted { get; set; }
        public SimpleNote()
        {
            User = new User();
            Color = new NoteColor();
        }

        public SimpleNote(int id, User? user, NoteColor? color, string? title, string? textt)
        {
            Id = id;
            User = user;
            Color = color;
            Title = title;
            Textt = textt;
        }

        public SimpleNote(int id, User? user, NoteColor? color, string? title, string? textt, DateTime datte, bool archived, bool deleted)
        {
            Id = id;
            User = user;
            Color = color;
            Title = title;
            Textt = textt;
            Datte = datte;
            Archived = archived;
            Deleted = deleted;
        }

        public void InsertNote()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_note_insert";
            cmd.Parameters.AddWithValue("spfk_iduser", User.Id);
            cmd.Parameters.AddWithValue("spfk_idcolor", Color.Id);
            cmd.Parameters.AddWithValue("sptitle", Title);
            cmd.Parameters.AddWithValue("sptextt", Textt);
        }

        public static SimpleNote GetById(int id)
        {
            var note = new SimpleNote();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM notes WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                note = new SimpleNote(
                    reader.GetInt32(0), // Id
                    User.GetById(reader.GetInt32(1)), // User
                    NoteColor.GetById(reader.GetInt32(2)), // Color
                    reader.GetString(3), // Title
                    reader.GetString(4), // Textt
                    reader.GetDateTime(5), // Datte
                    reader.GetBoolean(6), // Archived
                    reader.GetBoolean(7) // Deleted
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return note;
        }
        public static List<SimpleNote> GetList()
        {
            List<SimpleNote> notes = new List<SimpleNote>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM notes;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notes.Add(new SimpleNote(
                    reader.GetInt32(0), // Id
                    User.GetById(reader.GetInt32(1)), // User
                    NoteColor.GetById(reader.GetInt32(2)), // Color
                    reader.GetString(3), // Title
                    reader.GetString(4), // Textt
                    reader.GetDateTime(5), // Datte
                    reader.GetBoolean(6), // Archived
                    reader.GetBoolean(7)) // Deleted
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return notes;
        }

        public static List<SimpleNote> GetListByUser(int user)
        {
            List<SimpleNote> notes = new List<SimpleNote>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM notes WHERE fk_iduser = {user}";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notes.Add(new SimpleNote(
                    reader.GetInt32(0), // Id
                    User.GetById(reader.GetInt32(1)), // User
                    NoteColor.GetById(reader.GetInt32(2)), // Color
                    reader.GetString(3), // Title
                    reader.GetString(4), // Textt
                    reader.GetDateTime(5), // Datte
                    reader.GetBoolean(6), // Archived
                    reader.GetBoolean(7)) // Deleted
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return notes;
        }

        public bool UpdateNote()
        {
            var updated = false;
            if (Id < 1)
            {
                return updated;
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_note_update";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spfk_iduser", User.Id);
            cmd.Parameters.AddWithValue("spfk_idcolor", Color.Id);
            cmd.Parameters.AddWithValue("sptitle", Title);
            cmd.Parameters.AddWithValue("sptextt", Textt);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
    }
}
