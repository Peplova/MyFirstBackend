using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.Core.Dtos;
public class UserDto: IdConteiner
{ 
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<DeviceDto> Devices { get; set; }

}
