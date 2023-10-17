namespace Domain.IRepository;

public interface IUserRepository
{
    public Task<List<User>> GetAllUser();
    public Task<User> GetUserById(long id);
    public Task<User> GetUserByName(string name);
    public Task<User> GetUserByPhone(string phone);
    public Task Add(User user);
    public Task<int> Update(User user);
    public Task<int> DeleteById(long id);
}