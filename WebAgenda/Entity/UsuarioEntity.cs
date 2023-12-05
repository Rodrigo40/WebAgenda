namespace WebAgenda.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UsuarioEntity> ListaUsuario { get; set; }

        #region Padrão Singleton
        private static UsuarioEntity Instancia = null;
        public UsuarioEntity() { }
        public static UsuarioEntity GetInstancia()
        {
            if (Instancia==null)
            {
                Instancia = new UsuarioEntity();
            }
            return Instancia;
        }

        #endregion
    }
}
