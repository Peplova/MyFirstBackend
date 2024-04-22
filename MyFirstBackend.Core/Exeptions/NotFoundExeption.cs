

namespace MyFirstBackend.Core.Exeptions;

public class NotFoundExeption: Exception
{
    public NotFoundExeption(string message): base(message) 
    {
        
    }
}
