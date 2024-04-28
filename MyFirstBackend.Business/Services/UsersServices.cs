using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;
using MyFirstBackend.Core.Exeptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.Business.Services;

public class UsersServices : IUsersServices
{
    private readonly IUsersRepository _usersRepository;
    public UsersServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    public List<UserDto> GetUsers()
    {
        return _usersRepository.GetUsers();
    }
    public UserDto GetUserById(Guid Id)
    {
        return _usersRepository.GetUserById(Id);

    }
    public void DeleteUserById(Guid Id) 
    {
        var user = _usersRepository.GetUserById(Id);
        if (user is null) 
        {
            throw new NotFoundExeption($"Юзер с {Id} не найден");
        }
       // _usersRepository.DeleteUserById();
    }
}
