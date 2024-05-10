using System.ComponentModel.DataAnnotations;

namespace ProjetoListaTarefas.Models
{
    public class RelatorioTarefas
    {
        public int RelatorioId { get; set; }

        [Display(Name = "Nome Relatório")]
        public string? NomeRelatorio { get; set; }

        [Display(Name = "Status da Tarefa")]
        public string? StatusTarefa { get; set; }    
    }
}
