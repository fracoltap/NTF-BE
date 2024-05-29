namespace NTF_BE.Models.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetListUsers();
        Task<User> GetUser(int id);
        Task DeleteUser(User user);
        Task<User> AddUser(User user);
        Task UpdateUser(User user);
    }
}
