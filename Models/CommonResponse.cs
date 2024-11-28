using System.Net;

namespace dotnetproject.Models;

public class Response {
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }
}