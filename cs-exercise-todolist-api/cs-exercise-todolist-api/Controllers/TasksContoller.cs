using cs_exercise_todolist_api.Data;
using cs_exercise_todolist_api.Models;
using cs_exercise_todolist_api.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace cs_exercise_todolist_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksContoller : ControllerBase
    {
        private appDbContext _context;

        public TasksContoller(appDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTasksById(Guid taskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult PostTask(PostTaskDTO dto)
        {
            TaskModel newTask = new TaskModel
            {
                Categoria = dto.Categoria,
                Tarefa = dto.Tarefa
            };

            _context.Tasks.Add(newTask);
            var result = _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTask(Guid taskId, UpdateTaskDTO dto)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); }

            task.Tarefa = dto.Tarefa;
            task.Categoria = dto.Categoria;
            task.Concluido = dto.Concluido;

            _context.Update(task);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteTask(Guid taskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
