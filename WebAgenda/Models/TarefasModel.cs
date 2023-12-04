using MySql.Data.MySqlClient;
using System.Data;
using WebAgenda.Entity;

namespace WebAgenda.Models
{
    public class TarefasModel
    {
        // Listar Tarefas
        public List<TarefasEntity> ListarTarefas()
        {
            List<TarefasEntity> tarefas = new List<TarefasEntity>();
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            Conexao conx = new Conexao();

            try
            {
                con.ConnectionString = conx.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tarefas";

                MySqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        TarefasEntity entity = new TarefasEntity();
                        entity.Id = Convert.ToInt32(rd[0].ToString());
                        entity.Titulo = rd[1].ToString();
                        entity.Tarefa = rd[2].ToString();
                        entity.Data_Tarefa = rd[3].ToString();

                        tarefas.Add(entity);
                    }
                    rd.Close();
                }

            }
            catch (Exception)
            {

            }

            return tarefas;
        }
        public List<TarefasEntity> ListarTarefasById(int id)
        {
            List<TarefasEntity> tarefas = new List<TarefasEntity>();
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            Conexao conx = new Conexao();

            try
            {
                con.ConnectionString = conx.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from tarefas where id='{id}'";

                MySqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        TarefasEntity entity = new TarefasEntity();
                        entity.Id = Convert.ToInt32(rd[0].ToString());
                        entity.Titulo = rd[1].ToString();
                        entity.Tarefa = rd[2].ToString();
                        entity.Data_Tarefa = rd[3].ToString();

                        tarefas.Add(entity);
                    }
                    rd.Close();
                }

            }
            catch (Exception)
            {

            }

            return tarefas;
        }
        public string NovaTarefa(string titulo, string tarefa, string dataTarefa)
        {
            string resposta = string.Empty;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            Conexao conx = new Conexao();

            try
            {
                con.ConnectionString = conx.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"INSERT INTO tarefas(titulo,tarefa,data_tarefa)VALUES('{titulo}','{tarefa}','{dataTarefa}');";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "A tarefa foi registrada!";
                }
                else
                {
                    resposta = "Erro ao registrar tarefa!";
                }

            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string EditarTarefa(int id, string titulo, string tarefa, string dataTarefa)
        {
            string resposta = string.Empty;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            Conexao conx = new Conexao();

            try
            {
                con.ConnectionString = conx.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Update tarefas set titulo='{titulo}',tarefa='{tarefa}',data_tarefa='{dataTarefa}' where id='{id}';";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "A tarefa foi atualizada!";
                }
                else
                {
                    resposta = "Erro ao atualizar tarefa!";
                }

            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string EliminarTarefa(int id)
        {
            string resposta = string.Empty;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            Conexao conx = new Conexao();

            try
            {
                con.ConnectionString = conx.GetConnection();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Delete from tarefas where id='{id}';";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "A tarefa foi eliminada!";
                }
                else
                {
                    resposta = "Erro ao eliminar tarefa!";
                }

            }
            catch (Exception)
            {

            }

            return resposta;
        }

    }
}
