
using MySql.Data.MySqlClient;

namespace GestionEtudiantsCRUD
{
    public class DB
    {
        private MySqlConnection connection = new MySqlConnection(
            "server=localhost;database=gestion_etudiant;uid=root;pwd=;");

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
