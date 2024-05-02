using MyFirstBackend.Core.Enums;

namespace MyFirstBackend.Models.Responses;

public class DeviceResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DeviceType DeviceType { get; set; }
    public string Adress { get; set; }
}
