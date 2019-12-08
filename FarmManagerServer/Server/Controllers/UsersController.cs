using System;
using Domain.Dtos;
using Domain.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public ActionResult<UserRegistrationDto> Post(UserRegistrationDto user)
        {
            try
            {
                return _userService.Register(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("forgotten-password")]
        public ActionResult ForgetPassword(EntityHolder<UserForgetPasswordDto> entityHolder)
        {
            try
            {
                _userService.ForgetPassword(entityHolder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("changing-password")]
        public ActionResult ChangePassword(UserChangePassword user)
        {
            try
            {
                _userService.ChangePassword(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("token-valid")]
        public ActionResult CanChangePassword(RequestBodyParam<string> token)
        {
            try
            {
                _userService.CanChangePassword(token.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
