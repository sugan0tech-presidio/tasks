using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Serivces;

public interface IAuthService
{

    public string Login(LoginDTO person);
    public string Register(RegisterDTO person);
}