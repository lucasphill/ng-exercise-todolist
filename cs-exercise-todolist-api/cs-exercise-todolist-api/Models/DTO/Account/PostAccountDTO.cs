using System.ComponentModel.DataAnnotations;

namespace cs_exercise_todolist_api.Models.DTO.Account
{
    public class PostAccountDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
