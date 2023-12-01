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
    }
}
