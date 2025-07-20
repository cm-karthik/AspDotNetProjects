
namespace MyWebApp.Services;

internal sealed class PersonService : IPersonService
{
    public string GetName()
    {
        return "My name is Hello World!";
    }

    public string GetPersonName()
    {
        return "John Doe";
    }
}

public interface IPersonService
{
    string GetName();
}