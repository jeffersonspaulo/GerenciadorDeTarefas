using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.API.Models.Enums
{
    public enum TarefaStatus
    {
        [Display(Name = "Pendente")]
        Pendente = 1,

        [Display(Name = "Em Andamento")]
        EmAndamento = 2,

        [Display(Name = "Concluída")]
        Concluida = 3
    }
}
