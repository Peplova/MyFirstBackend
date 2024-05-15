

using AutoMapper;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;

namespace MyFirstBackend.Business.Services;

public class DevicesService : IDevicesService
{
    private readonly IDevicesRepository _devicesRepository;
    private readonly IMapper _mapper;
    public DevicesService(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }
    public DeviceDto GetDeviceById(Guid id) => _devicesRepository.GetDeviceById(id);
    public DeviceDto GetDeviceByUserId(Guid userId) => _devicesRepository.GetDeviceByUserId(userId);


}