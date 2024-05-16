using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.DataLayer.Repositories;

public interface IUsersRepository
{
    void AddDeviceToUser(Guid userId, Guid deviceId);
    Guid AddUser(UserDto dto);
    void DeleteDeviceFromUser(Guid userId, Guid deviceId);
    UserDto DeleteUserById(Guid Id);
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
}