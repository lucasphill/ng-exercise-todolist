using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cs_exercise_todolist_api.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Tarefa { get; set; }

        [Required]
        public string Categoria { get; set; }
        public bool Concluido { get; set; } = false;
    }
}
