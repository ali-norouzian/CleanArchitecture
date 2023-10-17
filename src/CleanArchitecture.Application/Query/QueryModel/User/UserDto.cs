using Domain;

namespace Application.Query.QueryModel.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UserStatus Status { get; set; }
        public int MaatLimitation { get; set; }
    }
}
