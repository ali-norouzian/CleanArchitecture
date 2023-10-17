using Application.Query.QueryModel.User;
using Application.Query.QueryService.Interfaces;
using Application.Query.QueryService.User.Mapper;
using Domain.IRepository;

namespace Application.Query.QueryService.Members
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUserRepository memberRepository)
        {
            _userRepository = memberRepository;
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            var users = await _userRepository.GetAllUser();
            if (users.Count == 0)
                return new List<UserDto>();

            var usersDto = users.Select(x => x.ToDto()).ToList();

            return usersDto;
        }

        public async Task<UserDto> GetUserById(long id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return null;

            var userDto = user.ToDto();

            return userDto;
        }

        public async Task<UserDto> GetUserByName(string name)
        {
            var user = await _userRepository.GetUserByName(name);
            if (user == null)
                return null;

            var userDto = user.ToDto();

            return userDto;
        }
    }
}
