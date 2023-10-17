using Application.Command.Commands.User;
using Application.Command.CoommandHandler.Interfaces;
using Application.Query.QueryService.Interfaces;
using CleanArchitecture.Presentation.Api.Controllers;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserCommandHandler _userCommandHandler;
        private const string Replacer = "%%%";
        private const string IsRequiredMessage = $"{Replacer} نمی تواند خالی باشد";
        private const string NotFoundMessage = $"کاربری {Replacer} یافت نشد";

        public UserController(IUserQueryService userQueryService, IUserCommandHandler userCommandHandler)
        {
            _userQueryService = userQueryService;
            _userCommandHandler = userCommandHandler;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            var results = await _userQueryService.GetAllUser();


            #region Validations

            if (results.Count == 0)
                return NotFound(new ResponseMessage(NotFoundMessage.Replace($"{Replacer} ", ""), ResponseStatus.UserNotfound));

            #endregion


            return Ok(results);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var result = await _userQueryService.GetUserById(id);


            #region Validations

            if (result == null)
                return NotFound(new ResponseMessage(NotFoundMessage.Replace($"{Replacer} ", ""), ResponseStatus.UserNotfound));

            #endregion


            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            #region Validations

            if (string.IsNullOrEmpty(command.Name))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "نام"), ResponseStatus.NameIsRequired));
            if (string.IsNullOrEmpty(command.Phone))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "شماره"), ResponseStatus.PhoneIsRequired));
            if (string.IsNullOrEmpty(command.Password))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "رمزعبور"), ResponseStatus.PasswordIsRequired));
            if (command.MaatLimitation == 0)
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "محدودیت مات"), ResponseStatus.MaatLimitationIsRequired));
            if (command.Status == 0)
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "وضعیت"), ResponseStatus.StatusIsRequired));

            #endregion


            await _userCommandHandler.AddUser(command);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            #region Validations

            if (string.IsNullOrEmpty(command.Name))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "نام"), ResponseStatus.NameIsRequired));
            if (string.IsNullOrEmpty(command.Phone))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "شماره"), ResponseStatus.PhoneIsRequired));
            if (string.IsNullOrEmpty(command.Password))
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "رمزعبور"), ResponseStatus.PasswordIsRequired));
            if (command.MaatLimitation == 0)
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "محدودیت مات"), ResponseStatus.MaatLimitationIsRequired));
            if (command.Status == 0)
                return BadRequest(new ResponseMessage(IsRequiredMessage.Replace("%%%", "وضعیت"), ResponseStatus.StatusIsRequired));

            #endregion


            var rowAffected = await _userCommandHandler.UpdateUser(command);


            #region Validations

            if (rowAffected == 0)
                return NotFound(new ResponseMessage(NotFoundMessage.Replace($"{Replacer} ", ""), ResponseStatus.UserNotfound));

            #endregion


            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var rowAffected = await _userCommandHandler.DeleteUser(command);


            #region Validations

            if (rowAffected == 0)
                return NotFound(new ResponseMessage(NotFoundMessage.Replace($"{Replacer} ", ""), ResponseStatus.UserNotfound));

            #endregion


            return Ok();
        }
    }
}

