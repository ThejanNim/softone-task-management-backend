using softone_task_management_backend.Domains.Dtos;

namespace softone_task_management_backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> SignUp(UserDto user);

        Task<UserDto> SignIn(UserDto user);
    }
}
