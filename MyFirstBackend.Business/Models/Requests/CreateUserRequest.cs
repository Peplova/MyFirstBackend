﻿namespace MyFirstBackend.Business.Models.Requests;

public class CreateUserRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}
