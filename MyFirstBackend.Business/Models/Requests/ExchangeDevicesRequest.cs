namespace MyFirstBackend.Business.Models.Requests;

public class ExchangeDevicesRequest
{
    public List<Guid> Devices { get; set; }
    public Guid UserIdFrom { get; set; }
    public Guid UserIdTo { get; set; }
}
