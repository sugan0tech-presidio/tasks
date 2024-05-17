using System.Security.Cryptography;
using System.Text;
using AwesomePizzas.Exceptions;
using AwesomePizzas.Models;
using AwesomePizzas.Models.DTO;
using AwesomePizzas.Repos;
using EmployeeRequestTrackerAPI.Interfaces;

namespace AwesomePizzas.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly ITokenService _tokenService;
    public UserService(IBaseRepo<User> repository, ITokenService tokenService) : base(repository)
    {
        _tokenService = tokenService;
    }

    public async Task<User> GetByEmail(string email)
    {
        return GetAll().Result.Find(u => u.Email.Equals(email)) ??
               throw new EntityNotFoundException("No user found for the email");
    }

    public async Task<LoginReturnDTO> Login(LoginDTO loginDto)
    {
        var user = await GetByEmail(loginDto.Email) ??
                   throw new AuthenticationException("Invalid Email");

        HMACSHA512 hasher = new(user.PasswordHashKey);

        var passwordHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        if (ComparePassword(passwordHash, user.Password))
        {
            var returnDto = user.ToLoginReturnDto();
            returnDto.Token = _tokenService.GenerateToken(user);
            return returnDto;

        }

        throw new System.Security.Authentication.AuthenticationException("Invalid email or password");
    }

    private bool ComparePassword(byte[] generatedHash, byte[] dbHash)
    {
        for (int i = 0; i < generatedHash.Length; i++)
        {
            if (generatedHash[i] != dbHash[i])
                return false;
        }

        return true;
    }

    public async Task<User> Register(RegisterDTO registerDto)
    {
        HMACSHA512 hasher = new();

        var user = new User
        {
            Email = registerDto.Email,
            Name = registerDto.Name,
            PasswordHashKey = hasher.Key,
            Password = hasher.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password))
        };

        user = await Repository.Add(user);

        return user;
    }
}