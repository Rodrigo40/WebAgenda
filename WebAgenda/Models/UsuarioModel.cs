using MySql.Data.MySqlClient;
using System.Data;
using WebAgenda.Entity;

namespace WebAgenda.Models
{
    public class UsuarioModel
    {
        private MySqlConnection con = null;
        private MySqlCommand cmd = null; // Comando para o banco de dados
        Conexao conex = new Conexao();

        public int Login(UsuarioEntity user)
        {
            int resposta = 0;
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = conex.GetConnection();
                con.Open();

                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Select * from usuario where email='{user.Email}' and password='{user.Password}'"; // Consulta Sql

                if (cmd.ExecuteNonQuery() == 1)
                    resposta = 1;
                else
                    resposta = 0;
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            finally
            {
                if (con != null) 
                {
                    con.Dispose();
                    cmd.Dispose();
                }
            }
            return resposta;
        }
    }
}
