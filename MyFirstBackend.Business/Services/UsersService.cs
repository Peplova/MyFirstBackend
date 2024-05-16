using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Business.Models.Requests;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.Core.Exeptions;
using MyFirstBackend.DataLayer.Repositories;
using Serilog;

namespace MyFirstBackend.Business.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersService>();
    private readonly string _pepper;
    private readonly int _iteration = 13;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
 
public Guid AddUser(UserDto user)
    {
        if (user.Age < 18 || user.Age > 99)
        {
            throw new ValidationException("Возраст указан неверно");
        }
        if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
        {
            throw new ValidationException("Неверный пароль");
        }
        return _usersRepository.AddUser(user);
    }
    public List<UserDto> GetUsers()
    {
        _logger.Information("");
        return (_usersRepository.GetUsers()).Select(t => t).ToList();
    }
    public UserDto GetUserById(Guid Id)
    {
        _logger.Information("Зовем метод репозитория");
        return _usersRepository.GetUserById(Id);

    }
    public void DeleteUserById(Guid Id)
    {
        var user = _usersRepository.GetUserById (Id);
        if (user is null)
        {
            throw new NotFoundExeption($"Юзер с {Id} не найден");
        }
       _usersRepository.DeleteUserById(Id);
    }
    public async void ExchangeDevices(ExchangeDevicesRequest request)
    {
        //var tempDevices = user1.Devices;
        //user1.Devices = user2.Devices;
        //user2.Devices = tempDevices;
        var userFrom = _usersRepository.GetUserById(request.UserIdFrom);
        if (userFrom == null)
            throw new Exception("Пользователь для обмена не найден или у него нет нужных устройств.");

        // Найти пользователя, с которым будут меняться (to)
        var userTo = _usersRepository.GetUserById(request.UserIdTo);
        if (userTo == null) 
        {
            throw new Exception("Пользователь для обмена не найден.");
        }

        // Проверить, есть ли у пользователя from устройства с нужными id
        var devicesToExchange = userFrom.Devices.Where(d => request.Devices.Contains(d.Id)).ToList();
        if (devicesToExchange.Count!= request.Devices.Count)
            throw new Exception("У пользователя нет устройств для обмена.");

        // Удалить устройства у пользователя from, добвить устроиство пользователю to
        foreach (var device in devicesToExchange)
        {
            _usersRepository.DeleteDeviceFromUser(userFrom.Id, device.Id);
            _usersRepository.AddDeviceToUser(userTo.Id, device.Id);
        }

    }
}



