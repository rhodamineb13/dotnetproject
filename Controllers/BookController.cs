using System.Net;
using Microsoft.AspNetCore.Mvc;
using dotnetproject.Models.Entities;
using dotnetproject.Models.DTO;
using dotnetproject.Data;
using dotnetproject.Usecase;
using dotnetproject.Repository;
using dotnetproject.Models;

namespace dotnetproject.Controllers;
public class BookController : Controller
{
    private readonly IBookUsecase _usecase;

    public BookController(IBookUsecase usecase) {
        this._usecase = usecase;
    }

    [HttpGet]
    [Route("/v1/books")]    
    public IActionResult GetAllBooks() {
        try {
            IEnumerable<BookDTO>? books = this._usecase.GetBooks(new BookPagination()); 

            return Ok(new Response {
                StatusCode = HttpStatusCode.OK,
                Message = "Successfully retrieved data",
                Data = books,
            });
        }
        catch (UnknownException ex) {
            return StatusCode((int)HttpStatusCode.InternalServerError, new Response {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = $"Unexpected error in making request: {ex}",
                Data = null,
            });
        }
    }
    
    [HttpGet]
    [Route("/v1/books/{bookId}")]
    public IActionResult GetBookInfoByID([FromRoute] int bookId) {
        try
        {
            BookDTO? book = this._usecase.FindBookByID(bookId);

            return Ok(new Response {
                StatusCode = HttpStatusCode.OK,
                Message = $"Found book with ID: {bookId}",
                Data = book
            });
        }
        catch (System.Exception)
        {
            return NotFound(new Response {
                StatusCode = HttpStatusCode.NotFound,
                Message = $"Book with ID {bookId} not found",
                Data = null
            });
        }
    }

    [HttpPost]
    [Route("/v1/books")]
    public IActionResult InsertNewBook([FromBody] BookDTO book) {
        try
        {
            BookDTO bookResult = this._usecase.CreateNewBook(book);
            return Ok(new Response{
                StatusCode = HttpStatusCode.Created,
                Message = "successfully inserted a new book into the database",
                Data= bookResult,
            });
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}