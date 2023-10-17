using Application.Command.Commands.User;

namespace Application.Command.CoommandHandler.Interfaces;

public interface IUserCommandHandler
{
    public Task AddUser(AddUserCommand command);
    public Task<int> UpdateUser(UpdateUserCommand command);
    public Task<int> DeleteUser(DeleteUserCommand command);
}