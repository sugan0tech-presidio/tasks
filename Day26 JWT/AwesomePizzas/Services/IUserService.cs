using AwesomePizzas.Models;
using AwesomePizzas.Models.DTO;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(LoginDTO loginDto);
        public Task<User> Register(RegisterDTO registerDto);
    }
}
