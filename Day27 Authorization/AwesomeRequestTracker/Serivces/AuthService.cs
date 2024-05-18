using System.Security.Cryptography;
using System.Text;
using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Services;
using AuthenticationException = System.Security.Authentication.AuthenticationException;

namespace AwesomeRequestTracker.Serivces;

public class AuthService
{
    private readonly IBaseService<User> _userService;
    private readonly IBaseService<Registry> _registryService;
    private readonly IBaseService<Employee> _employeeService;
    private readonly ITokenService _tokenService;

    public AuthService(IBaseService<User> userService, IBaseService<Employee> employeeService,
        IBaseService<Registry> registryService,
        ITokenService tokenService)
    {
        _userService = userService;
        _employeeService = employeeService;
        _registryService = registryService;
        _tokenService = tokenService;
    }

    public async Task<LoginReturnDTO> Login(LoginDTO loginDTO)
    {
        var userDb = _registryService.GetAll().Result.Find(registry => registry.Person.Email.Equals(loginDTO.Email));
        if (userDb == null)
            throw new AuthenticationException("Invalid username or password");

        HMACSHA512 hMACSHA = new HMACSHA512(userDb.HashKey);
        var hash = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
        bool isPasswordSame = ComparePassword(hash, userDb.PasswordHash);

        if (isPasswordSame)
        {
            if (!userDb.IsActivated)
                throw new UserNotActivatedException("Your account is not activated");

            return new LoginReturnDTO(_tokenService.GenerateToken(userDb.Person));
        }

        throw new Exceptions.AuthenticationException("Invalid username or password");
    }

    private bool ComparePassword(byte[] encrypterPass, byte[] password)
    {
        for (int i = 0; i < encrypterPass.Length; i++)
        {
            if (encrypterPass[i] != password[i])
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> Register(RegisterDTO registerDto)
    {
        Person person = _employeeService.GetAll().Result.Find(emp => emp.Id.Equals(registerDto.Id));
        if (person == null)
            person = _userService.GetAll().Result.Find(usr => usr.Id.Equals(registerDto.Id));

        try
        {
            var hasher = new HMACSHA512();
            var registry = new Registry();
            registry.Person = person;
            registry.HashKey = hasher.Key;
            registry.PasswordHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            _registryService.Add(registry);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        throw new AuthenticationException("Not able to register at this moment");
    }

}