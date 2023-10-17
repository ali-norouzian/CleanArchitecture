using Application.Query.QueryModel.User;

namespace Application.Query.QueryService.User.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(this Domain.User members)
        {
            var dto = new UserDto()
            {
                Id = members.Id,
                Name = members.Name,
                Status = members.Status,
                MaatLimitation = members.MaatLimitation
            };

            return dto;
        }
    }
}
