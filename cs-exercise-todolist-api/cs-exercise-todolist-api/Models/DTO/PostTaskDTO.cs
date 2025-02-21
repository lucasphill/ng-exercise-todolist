using System.ComponentModel.DataAnnotations;

namespace cs_exercise_todolist_api.Models.DTO
{
    public class PostTaskDTO
    {
        [Required]
        public string Tarefa { get; set; }

        [Required]
        public string Categoria { get; set; }
    }
}
