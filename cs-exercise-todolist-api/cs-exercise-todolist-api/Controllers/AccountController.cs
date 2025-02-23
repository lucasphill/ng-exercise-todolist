using cs_exercise_todolist_api.Models;
using cs_exercise_todolist_api.Models.DTO.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cs_exercise_todolist_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AccountModel> _userMananger;
        private SignInManager<AccountModel> _singInMananger;

        public AccountController(UserManager<AccountModel> userMananger, SignInManager<AccountModel> singInMananger)
        {
            _userMananger = userMananger;
            _singInMananger = singInMananger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAccount(PostAccountDTO dto) // Estou utilizando DTO (prefiro) mas poderia usar os campos direto no formulario do swagger (string Username, string Password)
        {
            AccountModel account = new AccountModel // Mapeia o usuário recebido pelo DTO para um usuário do AccountModel
            {
                UserName = dto.Username
            };
            IdentityResult result = await _userMananger.CreateAsync(account, dto.Password); // Adicionar o usuário com a senha recebida
            if (!result.Succeeded) { return BadRequest(); } // Caso a adição não dê certo retorna BadRequest código 400
            return Created(); // Retorna 201 quando ok
        }

        [HttpPost("login")]
        public IActionResult LoginAccount(LoginAccountDTO dto)
        {
            var result = _singInMananger.PasswordSignInAsync(dto.Username, dto.Password, false, false); // Faz o login pelo SignInManager do identity recebendo os dados pelo DTO
            if (!result.Result.Succeeded) // Verifica se login falhou
            {
                return Unauthorized();
            }

            return Ok(); // Retorna 200 Ok e o Identity adiciona um token do login aos cookies
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAccount()
        {
            await _singInMananger.SignOutAsync(); // Remove o cookie do login
            return NoContent();
        }
    }
}
