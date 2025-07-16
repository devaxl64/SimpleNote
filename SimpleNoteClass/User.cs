using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    public class User
    {
        public int Id { get; set; }
        public Level? Level { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Enable { get; set; }
        public User()
        {
            Level = new Level();
        }
        public User(int id, Level level, string name, string lastName, string email, string password, bool enable)
        {
            Id = id;
            Level = level;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Enable = enable;
        }

        public User(string name, string email, string password, Level level)
        {
            Name = name;
            Email = email;
            Password = password;
            Level = level;
        }

        public User(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
        public User(int id, string password)
        {
            Id = id;
            Password = password;
        }
        public static User Login(string email, string password)
        {
            User user = new User();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE email = '{email}' AND password = md5('{password}');";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user = new User(
                        reader.GetInt32(0), // Id
                        Level.GetById(reader.GetInt32(1)), // Level
                        reader.GetString(2), // Name
                        reader.GetString(3), // LastName
                        reader.GetString(4), // Email
                        reader.GetString(5), // Password
                        reader.GetBoolean(6) // Enable
                    );
            }
            reader.Close();
            cmd.Connection.Close();
            return user;
        }
        public void InsertUser()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_insert";
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sppassword", Password);
            cmd.Parameters.AddWithValue("spenable", Enable);
            cmd.Parameters.AddWithValue("spidlevel", Level.Id);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static User GetById(int id)
        {
            User user = new User();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user = new User(
                    reader.GetInt32(0), // Id
                    Level.GetById(reader.GetInt32(1)), // Level
                    reader.GetString(2), // Name
                    reader.GetString(3), // LastName
                    reader.GetString(4), // Email
                    reader.GetString(5), // Password
                    reader.GetBoolean(6) // Enable
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return user;
        }
        public static List<User> GetList()
        {
            List<User> users = new List<User>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE BY name;";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                users.Add(new User(
                    reader.GetInt32(0), // Id
                    Level.GetById(reader.GetInt32(1)), // Level
                    reader.GetString(2), // Name
                    reader.GetString(3), // LastName
                    reader.GetString(4), // Email
                    reader.GetString(5), // Password
                    reader.GetBoolean(6) // Enable
                    ));
            }
            reader.Close();
            cmd.Connection.Close();
            return users;
        }
        public bool UpdateUser()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spidlevel", Level.Id);
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            cmd.Parameters.AddWithValue("sppassword", Password);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
        public bool UpdateUserName()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update_name";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
        public bool UpdateUserPassword()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update_password";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("sppassword", Password);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
    }
}
