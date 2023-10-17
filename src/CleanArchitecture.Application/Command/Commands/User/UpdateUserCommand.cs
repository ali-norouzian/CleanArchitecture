using Domain;

namespace Application.Command.Commands.User
{
    public class UpdateUserCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public int MaatLimitation { get; set; }
    }
}
