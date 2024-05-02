using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;
using MyFirstBackend.Core.Exeptions;
using MyFirstBackend.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Data;

namespace MyFirstBackend.Business.Services;

public class UsersServices : IUsersServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersServices>();
    public UsersServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    public Guid AddUser(UserDto user)
    { 
        if (user.Age <18 || user.Age > 100) 
        {
            throw new ValidationException("Возраст указан неверно");
        }
        if (string.IsNullOrEmpty (user.Password)|| user.Password.Length < 8) 
        {
            throw new ValidationException("Неверный пароль");
        }
        return Guid.NewGuid();
    }
    public List<UserDto> GetUsers()
    {
        return _usersRepository.GetUsers();
    }
    public UserDto GetUserById(Guid Id)
    {
        _logger.Information("Зовем метод репозитория");
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
    public static void ExchangeDevices(User user1, User user2)
    {
        var tempDevices = user1.Devices;
        user1.Devices = user2.Devices;
        user2.Devices = tempDevices;
    }
}


