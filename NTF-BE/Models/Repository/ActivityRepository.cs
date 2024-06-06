using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AplicationDbContext _context;

        public ActivityRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            _context.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task DeleteActivity(Activity activity)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Activity>> GetListActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivity(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task UpdateActivity(Activity activity)
        {
            var activityItem = await _context.Activities.FirstOrDefaultAsync(x => x.Id == activity.Id);

            if (activityItem != null)
            {
                activityItem.Date = activity.Date;
                activityItem.Description = activity.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}

