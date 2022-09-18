using Library.Models;
using Microsoft.Data.SqlClient;

namespace Library;

public class Database
{
    private const string _connectionstring =
        "Server=.;Database=Library;User ID=sa;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True";

    private SqlConnection _conn;

    public Database()
    {
        _conn = new SqlConnection(_connectionstring);
        _conn.Open();
    }

    public SqlConnection Connection => _conn;

    ~Database()
    {
        _conn.Close();
    }
}