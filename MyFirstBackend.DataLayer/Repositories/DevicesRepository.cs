using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.DataLayer.Repositories;

public class DevicesRepository : BaseRepository, IDevicesRepository
{
    public DevicesRepository(BlackBookContext context) : base(context)
    {

    }
    public DeviceDto GetDeviceById(Guid id) => _ctx.Devices.FirstOrDefault(d => d.Id == id);
    public DeviceDto GetDeviceByUserId(Guid userId) => _ctx.Devices.FirstOrDefault(d => d.Owner.Id == userId);

}
