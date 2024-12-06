using Microsoft.AspNetCore.Mvc;
using dotnetproject.Usecase;
using dotnetproject.Models;
using System.Net;

namespace dotnetproject.Controllers;

public class UserController : Controller
{
    private readonly IUserUsecase _usecase;

    public UserController(IUserUsecase usecase) {
        this._usecase = usecase;
    }

    public async Task<IActionResult> SignUp([FromBody] UserDTO userDTO) {
        try
        {
            UserDTO userResult = await this._usecase.Register(userDTO);

            return Ok(new Response{
                StatusCode = HttpStatusCode.OK,
                Message = "user successfully registered",
                Data = userResult
            });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new Response {
                StatusCode = HttpStatusCode.BadRequest,
                Message = $"Bad request: {ex}",
                Data = null,
            });
        }
    }
}