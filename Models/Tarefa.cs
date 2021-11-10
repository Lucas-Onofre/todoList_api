using System.ComponentModel.DataAnnotations;

namespace todoListAPI.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "A atribuição de descrição é obrigatória!")] 
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}