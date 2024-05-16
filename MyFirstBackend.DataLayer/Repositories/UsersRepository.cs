using MyFirstBackend.Core.Dtos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.DataLayer.Repositories;


public class UsersRepository : BaseRepository, IUsersRepository
{
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersRepository>();
    public UsersRepository(BlackBookContext context) : base(context)
    {

    }
    public Guid AddUser(UserDto dto)
    {
        return Guid.NewGuid();
    }
    public List<UserDto> GetUsers()
    {
        return _ctx.Users.ToList();
    }
    public UserDto GetUserById(Guid Id)
    {
        _logger.Information("Идем в базу данных искать юзера с Id {id}", Id);
        return _ctx.Users.FirstOrDefault(x => x.Id == Id);


    }
    public UserDto DeleteUserById (Guid Id)
    {
        _logger.Information($"Deleted {Id}");
        return _ctx.Users.FirstOrDefault( x => x.Id == Id);
    }
    public void DeleteDeviceFromUser(Guid userId, Guid deviceId)
    {
        var user = _ctx.Users.FirstOrDefault(x => x.Id == userId);
        var device = user.Devices.FirstOrDefault(x => x.Id == deviceId);
        user.Devices.Remove(device);
        _ctx.SaveChanges();
    }
    public void AddDeviceToUser (Guid userId, Guid deviceId)
    {
        var user = _ctx.Users.FirstOrDefault(x => x.Id == userId);
        var device = user.Devices.FirstOrDefault(x => x.Id == deviceId);
        user.Devices.Add(device);
        _ctx.SaveChanges();
    }
}
