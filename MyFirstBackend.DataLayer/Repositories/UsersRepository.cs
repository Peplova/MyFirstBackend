using MyFirstBackend.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.DataLayer.Repositories;


public class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(BlackBookContext context) : base(context)
    {

    }
    public List<UserDto> GetUsers()
    {
        return _ctx.Users.ToList();
    }
    public UserDto GetUserById(Guid Id) => _ctx.Users.FirstOrDefault(x => x.Id == Id);
    
        
    
}
