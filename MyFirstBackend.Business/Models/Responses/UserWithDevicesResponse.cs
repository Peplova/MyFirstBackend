﻿namespace MyFirstBackend.Business.Models.Responses;

public class UserWithDevicesResponse: UserResponse
{
    public List<DeviceResponse> Devices { get; set; }   
}
