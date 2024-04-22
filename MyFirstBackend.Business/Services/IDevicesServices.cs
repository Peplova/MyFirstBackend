using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.Business.Services
{
    public interface IDevicesServices
    {
        DeviceDto GetDeviceById(Guid id);
        DeviceDto GetDeviceByUserId(Guid userId);
    }
}