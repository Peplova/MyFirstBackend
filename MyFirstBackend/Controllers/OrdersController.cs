using Microsoft.AspNetCore.Mvc;

namespace MyFirstBackend.Controllers;

[ApiController]
[Route("[controller]")]

public class OrdersController : Controller
{
    public OrdersController()
    {
        
    }
    [HttpGet]
    public int[] GetData()
    {
        return [1, 2 ];
    }
}
