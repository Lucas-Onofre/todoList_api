using System.ComponentModel.DataAnnotations;

namespace todoListAPI.Data.Dtos.Tarefa
{
    public class ReadTarefaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "A atribuição de descrição é obrigatória!")] 
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}