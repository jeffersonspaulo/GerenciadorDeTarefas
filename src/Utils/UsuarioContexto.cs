namespace GerenciadorDeTarefas.API.Utils
{
    public class UsuarioContexto
    {
        public int UsuarioId { get; set; }
        public string Funcao { get; set; }

        public UsuarioContexto(int usuarioId, string funcao)
        {
            UsuarioId = usuarioId;
            Funcao = funcao;
        }
    }
}
