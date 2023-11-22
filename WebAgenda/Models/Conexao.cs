using MySql.Data.MySqlClient;
using System.Data;

namespace WebAgenda.Models
{
    public class Conexao
    {
        private string Con = "server=localhost;database=agenda;uid=root;pwd=";

        public string TestarConexaoMySql()
        {
            string resposta = string.Empty;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Con);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    resposta = "Conexão aberta com sucesso!";
                }
                else
                {
                    resposta = "Erro ao abrir a conexão!";
                }
            }
            catch (Exception)
            {
                conn = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Dispose();
            }

            return resposta;
        }
        public string GetConnection()
        {
            return Con;
        }
    }
}
