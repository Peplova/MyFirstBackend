using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.Business.Services;

public interface IUsersServices
{
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
    void DeleteUserById(Guid Id);
    Guid AddUser(UserDto user);
}