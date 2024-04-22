﻿using MyFirstBackend.Core.Enums;

namespace MyFirstBackend.Core.Dtos;
public class DeviceDto: IdConteiner
{
    public string Name { get; set; }
    public DeviceType DeviceType { get; set; }
    public string Adress { get; set; }
    public UserDto Owner { get; set; }
}
