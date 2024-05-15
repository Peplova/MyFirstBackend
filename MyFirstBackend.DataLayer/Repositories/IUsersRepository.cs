using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.DataLayer.Repositories;

public interface IUsersRepository
{
    UserDto DeleteUserById(Guid Id);
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
}