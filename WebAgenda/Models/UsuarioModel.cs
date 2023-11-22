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
                con.ConnectionString = conex.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

            }
            catch (Exception)
            {

            }
            return resposta;
        }
    }
}
