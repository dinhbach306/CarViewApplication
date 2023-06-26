namespace Domain2.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : base() { }
    public BadRequestException(string msg) : base(msg) {}
    public BadRequestException(string msg, Exception inner) : base(msg, inner) {}
}