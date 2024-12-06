using dotnetproject.Helpers;
using dotnetproject.Models;
using dotnetproject.Models.DTO;
using dotnetproject.Models.Entities;
using dotnetproject.Repository;

namespace dotnetproject.Usecase;

public interface IUserUsecase {
    public Task<UserDTO?> Register(UserDTO userDTO);
    public Task<UserTokenDTO?> Login(UserLoginDTO userLoginDTO); 
}

public class UserUsecase : IUserUsecase {
    private readonly IUserRepository _repository;

    public UserUsecase(IUserRepository userRepository) {
        this._repository = userRepository;
    }
    public async Task<UserDTO?> Register(UserDTO userDTO) {
        string hashedPwd = Crypto.HashPassword(userDTO.Password);
            await this._repository.Register(new UserEntity{
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = hashedPwd,
                DateOfBirth = DateOnly.FromDateTime(userDTO.DateOfBirth ?? DateTime.MinValue),
                Address = userDTO.Address
            });
            return new UserDTO();
    }

    public async Task<UserTokenDTO?> Login(UserLoginDTO userLoginDTO) {
        throw new NotImplementedException();
    }
}