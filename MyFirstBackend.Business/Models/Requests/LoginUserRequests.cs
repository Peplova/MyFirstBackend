namespace MyFirstBackend.Models.Requests;

public class LoginUserRequests
{ 
    public string UserName { get; set; }
    public string PasswordSalt { get; set; }
    public string PasswordHash { get; set; }
}
