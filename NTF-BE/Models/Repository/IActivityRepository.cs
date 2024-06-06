namespace NTF_BE.Models.Repository
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetListActivities();
        Task<Activity> GetActivity(int id);
        Task DeleteActivity(Activity activity);
        Task<Activity> AddActivity(Activity activity);
        Task UpdateActivity(Activity activity);
    }
}
