using MyFirstBackend.Core.Dtos;
using MyFirstBackend.Models.Responses;

namespace MyFirstBackend.Business.Services;

public interface IUsersServices
{
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
    void DeleteUserById(Guid Id);
    Guid AddUser(UserDto user);
    void ExchangeDevices(UserWithDevicesResponse user1, UserWithDevicesResponse user2);
    
}