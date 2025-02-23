using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cs_exercise_todolist_api.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Tarefa { get; set; } // ex: Comprar maçã

        [Required]
        public string Categoria { get; set; } // ex: Casa
        public bool Concluido { get; set; } = false;

        [Required]
        public Guid AccountID { get; set; }
    }
}
