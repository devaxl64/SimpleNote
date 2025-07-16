using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    public class NoteColor
    {
        public int Id { get; set; }
        public int TypeColor { get; set; }
        public int Weight { get; set; }
        public bool Enable { get; set; }
        public NoteColor()
        {
        }
        public NoteColor(int id, int typeColor, int weight, bool enable)
        {
            Id = id;
            TypeColor = typeColor;
            Weight = weight;
            Enable = enable;
        }
        public NoteColor(int typeColor, int weight, bool enable)
        {
            TypeColor = typeColor;
            Weight = weight;
            Enable = enable;
        }
        public NoteColor(int typeColor, int weight)
        {
            TypeColor = typeColor;
            Weight = weight;
        }
        public void InsertColor()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_color_insert";
            cmd.Parameters.AddWithValue("sptypecolor", TypeColor);
            cmd.Parameters.AddWithValue("spwight", Weight);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static NoteColor GetById(int id)
        {
            var color = new NoteColor();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM simplenote.colors WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                color = new NoteColor(
                    reader.GetInt32(0), // Id    
                    reader.GetInt32(1), // TypeColor
                    reader.GetInt32(2), // Weight
                    reader.GetBoolean(3) // Enable
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return color;

        }
        public static bool DisableColor(int id)
        {
            bool disabled = false;
            if (id <= 0)
            {
                return disabled;
                throw new Exception("Não foi possível atulizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"UPDATE simplenote.colors SET enable = 0 WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (cmd.ExecuteNonQuery() > 0)
            {
                disabled = true;
            }
            cmd.Connection.Close();
            return disabled;
        }

    }
}
