using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            var userItem = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userItem != null)
            {
                userItem.Name = user.Name;
                userItem.Email = user.Email;
                userItem.IsActive = user.IsActive;
                userItem.EmailConfirmed = user.EmailConfirmed;

                await _context.SaveChangesAsync();
            }

        }

    }
}
