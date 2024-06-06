namespace NTF_BE.Models.Repository
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetListInventory();
        Task<Inventory> GetInventory(int id);
        Task DeleteInventory(Inventory user);
        Task<Inventory> AddInventory(Inventory user);
        Task UpdateInventory(Inventory user);
    }
}
