using Microsoft.AspNetCore.Mvc;
using softone_task_management_backend.Domains.Dtos;
using softone_task_management_backend.Services.Interfaces;

namespace softone_task_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("signup")]
        public async Task<UserDto> SignUp(UserDto user)
        {
            return await this._authService.SignUp(user);
        }

        [HttpPost("signin")]
        public async Task<UserDto> SignIn(UserDto user)
        {
            return await this._authService.SignIn(user);
        }
    }
}
