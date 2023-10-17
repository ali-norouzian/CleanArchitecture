using Application.Command.Commands.User;
using Application.Command.CoommandHandler.Interfaces;
using Application.Query.QueryService.Account.Helper;
using Domain.IRepository;
using Domain;

namespace Application.Command.CoommandHandler
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(AddUserCommand command)
        {
            var user = new User()
            {
                Name = command.Name,
                Phone = command.Phone,
                Password = await PasswordHelper.HashPassword(command.Password),
                Status = command.Status,
                MaatLimitation = command.MaatLimitation
            };

            await _userRepository.Add(user);
        }

        public async Task<int> UpdateUser(UpdateUserCommand command)
        {
            var user = await _userRepository.GetUserById(command.Id);
            if (user == null)
                return 0;

            user.Name = command.Name;
            user.Phone = command.Phone;
            user.Password = await PasswordHelper.HashPassword(command.Password);
            user.Status = command.Status; user.MaatLimitation = command.MaatLimitation;

            var rowAffected = await _userRepository.Update(user);

            return rowAffected;
        }

        public async Task<int> DeleteUser(DeleteUserCommand command)
        {
            var rowAffected = await _userRepository.DeleteById(command.UserId);

            return rowAffected;
        }
    }
}
