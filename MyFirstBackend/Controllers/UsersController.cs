
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Migrations;
using MyFirstBackend.Middlewares;
using MyFirstBackend.Models.Requests;
using MyFirstBackend.Models.Responses;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFirstBackend.Controllers;

[ApiController]
[Route("/api/users")]

public class UsersController : Controller
{
    private readonly IUsersServices _usersServices;
    private readonly IDevicesServices _devicesServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();
    public UsersController(IUsersServices usersService)
    {
        _usersServices = usersService;
    }
    [Authorize]
    [HttpGet]
    public ActionResult<List<UserResponse>> GetUsers()
    {
        _usersServices.GetUsers();
        return Ok(new List<UserResponse>());
    }
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<UserWithDevicesResponse> GetUserById(Guid id)
    {
        _logger.Information($"Получаем юзера по айди {id}");
        _usersServices.GetUserById(Guid.NewGuid());
        return Ok(new UserWithDevicesResponse());
    }
    [HttpPost]
    public ActionResult <Guid> CreateUser([FromBody] CreateUserRequest request)
    {
        _logger.Information($"{request.UserName} {request.Password}");
       var id = _usersServices.AddUser(new()
        {
            Password = request.Password,
            UserName = request.UserName,
            Age = request.Age,
            Email = request.Email,
        });
        return Ok(id);
    }
    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> Login([FromBody] LoginUserRequests user)
    {
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        if (user.UserName == "johndoe" && user.Password == "def@123")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myFirstbackend_superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "MyFirstBackend",
                audience: "UI",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }
        return Unauthorized();
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

    [HttpPatch("/devices")]
    public ActionResult <UserWithDevicesResponse>ExchangeDevices(UserWithDevicesResponse user1, UserWithDevicesResponse user2)
    {
        _usersServices.ExchangeDevices(user1.Devices, user2.Devices);
        return Ok (new UserWithDevicesResponse());
    }
}
