using MyFirstBackend.Business.Models.Requests;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.Models.Responses;

namespace MyFirstBackend.Business.Services;

public interface IUsersService
{
    UserDto GetUserById(Guid Id);
    List<UserDto> GetUsers();
    void DeleteUserById(Guid Id);
    Guid AddUser(UserDto user);
    void ExchangeDevices(ExchangeDevicesRequest request);
    
}