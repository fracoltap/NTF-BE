using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class InventoryRepository : IInventoryRepository
    {

        private readonly AplicationDbContext _context;

        public InventoryRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            _context.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task DeleteInventory(Inventory inventory)
        {
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Inventory>> GetListInventory()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<Inventory> GetInventory(int id)
        {
            return await _context.Inventory.FindAsync(id);
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            var inventoryItem = await _context.Inventory.FirstOrDefaultAsync(x => x.Id == inventory.Id);

            if (inventoryItem != null)
            {
                inventoryItem.Name = inventory.Name;
                inventoryItem.Quantity = inventory.Quantity;
                inventoryItem.CreatedDate = inventory.CreatedDate;
                await _context.SaveChangesAsync();
            }

        }

    }
}
