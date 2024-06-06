using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NTF_BE.Models.Repository
{
    public class FarmProductionRepository : IFarmProductionRepository
    {

        private readonly AplicationDbContext _context;

        public FarmProductionRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FarmProduction> AddFarmProduction(FarmProduction farmProduction)
        {
            _context.Add(farmProduction);
            await _context.SaveChangesAsync();
            return farmProduction;
        }

        public async Task DeleteFarmProduction(FarmProduction farmProduction)
        {
            _context.FarmProductions.Remove(farmProduction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FarmProduction>> GetListFarmProductions()
        {
            return await _context.FarmProductions.ToListAsync();
        }

        public async Task<FarmProduction> GetFarmProduction(int id)
        {
            return await _context.FarmProductions.FindAsync(id);
        }

        public async Task UpdateFarmProduction(FarmProduction farmProduction)
        {
            var farmProductionItem = await _context.FarmProductions.FirstOrDefaultAsync(x => x.Id == farmProduction.Id);

            if (farmProductionItem != null)
            {
                farmProductionItem.Id = farmProduction.Id;
                farmProductionItem.FarmId = farmProduction.FarmId;
                farmProductionItem.ProductId = farmProduction.ProductId;
                farmProductionItem.Month = farmProduction.Month;
                farmProductionItem.Year = farmProduction.Year;
                farmProductionItem.ProducedQuantity = farmProduction.ProducedQuantity;
                farmProductionItem.Unit = farmProduction.Unit;
                await _context.SaveChangesAsync();
            }

        }

    }
}
