using cs_exercise_todolist_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_exercise_todolist_api.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
