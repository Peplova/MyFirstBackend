using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.DataLayer.Repositories;

public interface IUsersRepository
{
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
}