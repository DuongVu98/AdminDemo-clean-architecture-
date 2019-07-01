using MySql.Data.MySqlClient;

namespace AdminDemo.Usecases.DatabaseConfiguration
{
    public class DatabaseConnectionConfiguration
    {
        public static MySqlConnection GetDatabaseConnection()
        {
            string hostname = "localhost";
            string port = "3306";
            string username = "root";
            string password = "1234";
            string database = "mydb";

            string connectionString = "Server=" + hostname + ";Database=" + database + ";port=" + port + ";User Id=" +
                                      username + ";password=" + password;
            
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}