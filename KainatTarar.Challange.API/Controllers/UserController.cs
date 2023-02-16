using KainatTarar.Challange.API.Controllers.Base;
using KainatTarar.Challange.Model.Dtos;
using KainatTarar.Challange.Model.Shared;
using KainatTarar.Challange.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KainatTarar.Challange.API.Controllers
{
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Result<Tuple<LoginResult, string>>> Login([FromBody] LoginInput loginInput)
        {
            try
            {
                UserManager userManager = new();

                LoginResult loginResult = userManager.LoginControl(username: loginInput.Username, password: loginInput.Password);
                if (loginResult != null)
                {
                    Shared shared = new Shared();
                    string token = shared.GenerateToken(loginResult: loginResult);
                    return Ok(new Result<Tuple<LoginResult, string>>()
                    {
                        Success = true,
                        Data = new Tuple<LoginResult, string>(loginResult, token)
                    });

                }
                return NotFound(new Result<Tuple<LoginResult, string>>() { Success = false, Message = "Username or password is incorrect. Please try again!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<Tuple<LoginResult, string>>() { Success = false, Message = MyExceptionHandler.GetAllExceptionMessages(exception: ex) });
            }
        }


        [HttpGet("GetGreeting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Result<string>> GetGreeting(string name)
        {
            try
            {
                UserManager userManager = new();
                string result = userManager.GetGreeting(name: name);

                return Ok(new Result<string>()
                {
                    Success = true,
                    Message = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<string>() { Success = false, Message = MyExceptionHandler.GetAllExceptionMessages(exception: ex) });
            }


        }
    }
}