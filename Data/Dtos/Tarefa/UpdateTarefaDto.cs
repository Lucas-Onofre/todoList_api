using System.ComponentModel.DataAnnotations;

namespace todoListAPI.Data.Dtos.Tarefa
{
    public class UpdateTarefaDto
    {
        [Required(ErrorMessage = "A atribuição de descrição é obrigatória!")] 
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}