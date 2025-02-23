using cs_exercise_todolist_api.Data;
using cs_exercise_todolist_api.Models;
using cs_exercise_todolist_api.Models.DTO.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cs_exercise_todolist_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksContoller : ControllerBase
    {
        private appDbContext _context;
        private UserManager<AccountModel> _userManager;

        public TasksContoller(appDbContext context, UserManager<AccountModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<TaskModel>?> GetTasksAsync() // Lista todas as Tasks
        {
            var user = await _userManager.GetUserAsync(User); // Recebe o usuário logado pelo UserManager
            if (user == null) { return null; }

            return _context.Tasks.Where(u => u.AccountID == Guid.Parse(user.Id)).ToList(); // Retorna uma lista de objeto Task do usuário logado
        }

        [HttpGet("{taskId}")]
        [Authorize]
        public IActionResult GetTasksById(Guid taskId) // Retorna apenas uma Task
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); } // Se não encontrar a Task com Id retorna 400 notFound

            return Ok(task); // Retorna o objeto do Id e informa que deu certo codigo 200
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTask(PostTaskDTO dto) // Adiciona uma Task
        {
            var user = await _userManager.GetUserAsync(User); // Recebe o usuário logado pelo UserManager
            if (user == null) { return Unauthorized(); } 

            TaskModel newTask = new TaskModel // Mapeia os dados recebidos em DTO para um objeto Task
            {
                Categoria = dto.Categoria,
                Tarefa = dto.Tarefa,
                AccountID = Guid.Parse(user.Id) // Adiciona o Id do usuário logado no objeto mas antes transforma de string para GUID
            };

            _context.Tasks.Add(newTask);
            var result = _context.SaveChanges();

            return Created(); // Não retorna o objeto, apenas que foi criado código 201
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateTask(Guid taskId, UpdateTaskDTO dto) // Atualiza uma Task recebendo Id e todos dados
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); } // Se não encontrar a Task com Id retorna 400 notFound

            task.Tarefa = dto.Tarefa;
            task.Categoria = dto.Categoria;
            task.Concluido = dto.Concluido;

            _context.Update(task);
            _context.SaveChanges();

            return Accepted(); // Não retorna o objeto apenas que foi aceito código 202
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteTask(Guid taskId) // Remove uma Task recebendo Id
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) { return NotFound(); } // Se não encontrar a Task com Id retorna 400 notFound

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
