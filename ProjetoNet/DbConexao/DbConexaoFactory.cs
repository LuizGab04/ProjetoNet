using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

public class DbConexaoFactory
{
    private readonly string _connectionString;

    public DbConexaoFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
