using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Cooperativa_Agricola
{
    public class Banco
    {
        // Conexao padrao do XAMPP (MariaDB/MySQL): localhost, porta 3306, usuario root, sem senha
        private static string connectionString =
            "Server=localhost;Port=3306;Database=cooperativa_agricola;Uid=root;Pwd=;";

        // Executa comandos sem retorno (INSERT, UPDATE, DELETE) usando parametros
        public static void ExecutarComando(string sql, Dictionary<string, object> parametros)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        foreach (var p in parametros)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Executa INSERT e retorna o ultimo ID gerado pelo AUTO_INCREMENT
        public static int ExecutarEObterId(string sql, Dictionary<string, object> parametros)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        foreach (var p in parametros)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.LastInsertedId);
                }
            }
        }

        // Executa SELECT e devolve os dados em um DataTable
        public static DataTable Consultar(string sql, Dictionary<string, object> parametros = null)
        {
            var tabela = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        foreach (var p in parametros)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }

                    using (var adapter = new MySqlDataAdapter(cmd))
                        adapter.Fill(tabela);
                }
            }
            return tabela;
        }
    }
}
