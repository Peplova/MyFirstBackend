using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.DataLayer.Repositories
{
    public interface IDevicesRepository
    {
        DeviceDto GetDeviceById(Guid id);
        DeviceDto GetDeviceByUserId(Guid userId);
    }
}