using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Domain2.Model.Response;

public class Status
{
    public Status(HttpStatusCode statusCode, string? message, object? data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}