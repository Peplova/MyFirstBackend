using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.Controllers;

[ApiController]
[Route("/api/users")]

public class UsersController : Controller
{
    private readonly IUsersServices _usersServices;
    public UsersController(IUsersServices usersService)
    {
        _usersServices = usersService;
    }
    [HttpGet]
    public List<UserDto> GetUsers()
    {
        return _usersServices.GetUsers();
    }
    [HttpGet("{id}")]
    public UserDto GetUserById(Guid id)
    {
        return _usersServices.GetUserById(Guid.NewGuid());
    }
    [HttpPost]
    public Guid CreateUser(object request)
    {
        return Guid.NewGuid();
    }
    [HttpPut("{id}")]
    public Guid UpdateUser([FromRoute] Guid id, [FromBody]object request)
    {
        return Guid.NewGuid();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteUserById(Guid id)
    {
            _usersServices.DeleteUserById(id);
        
        return NoContent();
    }
   

}
