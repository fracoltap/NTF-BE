namespace NTF_BE.Models.Repository
{
    public interface IFarmProductionRepository
    {
        Task<List<FarmProduction>> GetListFarmProductions();
        Task<FarmProduction> GetFarmProduction(int id);
        Task DeleteFarmProduction(FarmProduction farmProduction);
        Task<FarmProduction> AddFarmProduction(FarmProduction farmProduction);
        Task UpdateFarmProduction(FarmProduction farmProduction);
    }
}
