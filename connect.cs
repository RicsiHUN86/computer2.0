using MySql.Data.MySqlClient;
using System;
using System.Data;

public class Connect
{
    private const string connectionString = "server=localhost;database=computer;user=root;password=;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public static DataTable GetData(string query)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }

    public static void UpdateData(string query)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
