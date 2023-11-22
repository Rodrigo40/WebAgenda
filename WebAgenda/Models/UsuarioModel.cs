using MySql.Data.MySqlClient;
using System.Data;
using WebAgenda.Entity;

namespace WebAgenda.Models
{
    public class UsuarioModel
    {
        // Metodo de login
        public int Login(UsuarioEntity user)
        {
            // Instanciando a class de conexão string
            Conexao conex = new Conexao();
            int resposta = 0;
            try
            {
                //Instanciando a class de conexão do MySql
                MySqlConnection con = new MySqlConnection();
                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Instanciando a class de comando do MySql
                MySqlCommand cmd = new MySqlCommand();
                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"Select * from usuario where email='{user.Email}' and password='{user.Password}'"; // Consulta Sql

                //Definindo o objeto MySqlDataReader para executar o comando
                //E Ler a resposta ou seja: trará a resposta do comando
                MySqlDataReader adapter = cmd.ExecuteReader();
                
                //Verifinado se exitem linhas na resposta do comando
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
