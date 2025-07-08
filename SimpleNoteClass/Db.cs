using MySql.Data.MySqlClient;


namespace SimpleNoteClass
{
    public static class Db
    {
        public static string StrConn { get; set; }

        public static MySqlCommand OpenDb(string strConn = "")
        {
            MySqlCommand cmd = new MySqlCommand();
            StrConn = strConn;
            StrConn = $@"server=127.0.0.1;database=simplenote;user=root;password=";
            cmd.Connection = new MySqlConnection(StrConn);
            try
            {
                cmd.Connection.Open();
                Console.WriteLine($"Conexão com o banco de dados estabelecida com sucesso! {cmd.Connection.ServerVersion}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Erro ao tentar abrir uma conexão com o banco de dados: : {ex.Message}");
                throw;
            }
            return cmd;
        }

    }
}
