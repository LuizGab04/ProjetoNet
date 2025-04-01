using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

public class DbConexaoFactory
{
    private readonly string _connectionString;

    public DbConexaoFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    // Método para testar a conexão
    public async Task<bool> TestarConexao()
    {
        try
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                await conexao.OpenAsync();
                Console.WriteLine("✅ Conexão com o banco bem-sucedida!");
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao conectar ao banco: {ex.Message}");
            return false;
        }
    }
}