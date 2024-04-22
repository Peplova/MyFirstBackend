

using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;

namespace MyFirstBackend.Business.Services;

public class DevicesServices : IDevicesServices
{
    private readonly IDevicesRepository _devicesRepository;
    public DevicesServices(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }
    public DeviceDto GetDeviceById(Guid id) => _devicesRepository.GetDeviceById(id);
    public DeviceDto GetDeviceByUserId(Guid userId) => _devicesRepository.GetDeviceByUserId(userId);


}