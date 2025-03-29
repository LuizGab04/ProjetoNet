using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

public class DbConexaoFactory
{
    private readonly string _connectionString;

    public DbConexaoFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}