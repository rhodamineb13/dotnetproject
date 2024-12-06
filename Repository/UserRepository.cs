using System;
using dotnetproject.Data;
using dotnetproject.Models;
using dotnetproject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetproject.Repository;

public interface IUserRepository {
    public Task Register(UserEntity userEntity);
    public Task<UserEntity> Login(string email);
}

public class UserRepository : IUserRepository {
    private readonly ApplicationContext? _db;

    public async void Register(UserEntity userEntity) {
        UserEntity? res = await this._db.Users.FirstOrDefaultAsync(u => u.Email == userEntity.Email);
        if (res != null) {
            throw new UserRegisteredException();
        }

        try
        {
           await this._db.Users.AddAsync(userEntity);
           await this._db.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            throw new UnknownException($"unknown Exception {ex}");
        }
    }

    public async Task<UserEntity> Login(string email) {
        try
        {
            UserEntity? userResult = await this._db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userResult == null) {
                throw new UserNotFoundException("user doesn't exist");
            }
            return userResult;
        }
        catch (Exception ex)
        {
            throw new UnknownException($"unknown exception caught: {ex}");
        }
    }
}