using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.Business.Services
{
    public interface IDevicesService
    {
        DeviceDto GetDeviceById(Guid id);
        DeviceDto GetDeviceByUserId(Guid userId);
    }
}