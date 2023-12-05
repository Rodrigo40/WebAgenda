namespace WebAgenda.Entity
{
    public class TarefasEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tarefa { get; set; }
        public string Data_Tarefa { get; set; }
        public int Status { get; set; }
        public List<TarefasEntity> ListaTarefas { get; set;}
    }
}
