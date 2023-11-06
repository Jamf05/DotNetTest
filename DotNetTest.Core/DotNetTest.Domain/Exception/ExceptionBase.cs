namespace DotNetTest.Domain.Exception;

public class ExceptionBase : System.Exception
{
    public int Code;
    protected ExceptionBase() : base() { }
    protected ExceptionBase(string message) : base(message) { }

    protected ExceptionBase(int code, string message) : base(message)
    {
        Code = code;
    }
}