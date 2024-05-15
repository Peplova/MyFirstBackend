
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstBackend.Business.Models.Requests;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Business.Validation;
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
    private readonly IUsersService _usersServices;
    private readonly IDevicesService _devicesServices;
    private readonly IValidationContext _validationContext;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();
    
    public UsersController(IUsersService usersService)
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
        var validator = new UserCreateRequestValidation();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        _logger.Information($"{request.UserName} {request.Password}");
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var pepper = "your_pepper_here";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password + pepper, salt, 12);
        var id = _usersServices.AddUser(new()
        {
            Password = hashedPassword,
            UserName = request.UserName,
            Age = request.Age,
            Email = request.Email,
        });
        return Ok(id);
    }

    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> Login([FromBody] LoginUserRequest user)
    {
        var validator = new LoginUserRequestsValidator();
        var validationResult = validator.Validate(user);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySecretcodding_superSecretKey@345"));
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

    [HttpPatch("/exchange-devices")]
    public ActionResult ExchangeDevices([FromBody] ExchangeDevicesRequest request)
    {
        _usersServices.ExchangeDevices(request);
        return NoContent();
    }
}
