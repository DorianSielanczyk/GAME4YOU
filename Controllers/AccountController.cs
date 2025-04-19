using GAME4YOU.Entities;
using GAME4YOU.Models;
using GAME4YOU.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto dto)
    {
        var currentEmail = User.FindFirstValue("email");
        if (currentEmail == null)
            return Unauthorized();

        var success = await _accountService.UpdateUser(currentEmail, dto);
        if (!success)
            return NotFound("Użytkownik nie znaleziony");

        return Ok("Dane zaktualizowane");
    }
}