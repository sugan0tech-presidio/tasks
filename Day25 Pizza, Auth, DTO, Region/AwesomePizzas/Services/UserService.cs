﻿using System.Security.Cryptography;
using System.Text;
using AwesomePizzas.Exceptions;
using AwesomePizzas.Models;
using AwesomePizzas.Models.DTO;
using AwesomePizzas.Repos;

namespace AwesomePizzas.Services;

public class UserService : BaseService<User>
{
    public UserService(IBaseRepo<User> repository) : base(repository)
    {
    }

    public async Task<User> GetByEmail(string email)
    {
        return GetAll().Result.Find(u => u.Email.Equals(email)) ??
               throw new EntityNotFoundException("No user found for the email");
    }

    public async Task<User> Login(LoginDTO loginDto)
    {
        var user = await GetByEmail(loginDto.Email) ??
                   throw new AuthenticationException("Invalid Email");

        HMACSHA512 hasher = new(user.PasswordHashKey);

        var passwordHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        if (ComparePassword(passwordHash, user.Password))
            return user;

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