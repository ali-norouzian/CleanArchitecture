using Domain;

namespace Application.Command.Commands.User
{
    public class AddUserCommand
    {
        public string Name { get; set; }
        public UserStatus Status { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int MaatLimitation { get; set; }
    }
}
