using MySql.Data.MySqlClient;
using System.Data;
using WebAgenda.Entity;

namespace WebAgenda.Models
{
    public class UsuarioModel
    {
        //private MySqlConnection con = null;
        //private MySqlCommand cmd = null; // Comando para o banco de dados

        public int Login(UsuarioEntity user)
        {
            Conexao conex = new Conexao();
            int resposta = 0;
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = conex.GetConnection();
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Select * from usuario where email='{user.Email}' and password='{user.Password}'"; // Consulta Sql

                MySqlDataReader adapter = cmd.ExecuteReader();
                
                if (adapter.HasRows)
                {
                    resposta = 1;
                }                  
                else
                    resposta = 0;
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }
}
