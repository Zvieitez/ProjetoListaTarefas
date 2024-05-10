using System.ComponentModel.DataAnnotations;

namespace ProjetoListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? NomeTarefa { get; set; }
        public string? Descricao { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime DtInicio { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        public DateTime DtFim { get; set; }

        [Display(Name = "Status da Tarefa")]
        public string? StatusTarefa { get; set; }
    }
}
