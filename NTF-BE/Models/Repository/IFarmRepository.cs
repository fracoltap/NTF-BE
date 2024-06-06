namespace NTF_BE.Models.Repository
{
    public interface IFarmRepository
    {
        Task<List<Farm>> GetListFarms();
        Task<Farm> GetFarm(int id);
        Task DeleteFarm(Farm farm);
        Task<Farm> AddFarm(Farm farm);
        Task UpdateFarm(Farm farm);
    }
}
