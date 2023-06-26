namespace Domain2.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException() : base() { }
    public InternalServerException(string msg) : base(msg) {}
    public InternalServerException(string msg, Exception inner) : base(msg, inner) {}
}