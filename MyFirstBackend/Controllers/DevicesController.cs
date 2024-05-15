using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;
namespace MyFirstBackend.Controllers;
[Authorize]
[ApiController]
[Route("/api/devices")]

public class DevicesController : Controller
{
    private readonly IDevicesService _devicesServices;
    public DevicesController(IDevicesService deviceServices)
    {
        _devicesServices = deviceServices;
    }
    [HttpGet("{id}")]
    public ActionResult<DeviceDto> GetDeviceById(Guid id)
    {
        return _devicesServices.GetDeviceById(id);
    }
    [HttpGet("/user-by/{userid}")]
    public DeviceDto GetDeviceByUserId(Guid userId)
    {
        return _devicesServices.GetDeviceByUserId(userId);
    }

}
