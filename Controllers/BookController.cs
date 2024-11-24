using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetproject.Models;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

}