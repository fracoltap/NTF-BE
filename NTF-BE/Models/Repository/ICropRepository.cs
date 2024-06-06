namespace NTF_BE.Models.Repository
{
    public interface ICropRepository
    {
        Task<List<Crop>> GetListCrops();
        Task<Crop> GetCrop(int id);
        Task DeleteCrop(Crop crop);
        Task<Crop> AddCrop(Crop crop);
        Task UpdateCrop(Crop crop);
    }
}
