using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.API.Models.Enums
{
    public enum Prioridade
    {
        [Display(Name = "Baixa")]
        Baixa = 1,

        [Display(Name = "Média")]
        Media = 2,

        [Display(Name = "Alta")]
        Alta = 3
    }
}
