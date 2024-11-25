using System;
namespace dotnetproject.Models;

public class UnknownException : Exception
{
    public UnknownException() { }
    public UnknownException(string message) : base(message) { }
    public UnknownException(string message, Exception inner) : base(message, inner) { }
    
}

public class NotFoundException : Exception {
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
}

public class NotCreatedException : Exception {
    public NotCreatedException() { }
    public NotCreatedException(string message) : base(message) { }
    public NotCreatedException(string message, Exception inner) : base(message, inner) { }
}