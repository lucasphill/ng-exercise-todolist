using Microsoft.AspNetCore.Identity;

namespace cs_exercise_todolist_api.Models
{
    public class AccountModel : IdentityUser
    {
        public virtual ICollection<TaskModel>? Tasks { get; set; }

        public AccountModel() : base() { }
    }
}
