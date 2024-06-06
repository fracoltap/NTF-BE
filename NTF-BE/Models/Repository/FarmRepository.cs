using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class FarmRepository : IFarmRepository
    {

        private readonly AplicationDbContext _context;

        public FarmRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Farm> AddFarm(Farm farm)
        {
            _context.Add(farm);
            await _context.SaveChangesAsync();
            return farm;
        }

        public async Task DeleteFarm(Farm farm)
        {
            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Farm>> GetListFarms()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task UpdateFarm(Farm farm)
        {
            var farmItem = await _context.Farms.FirstOrDefaultAsync(x => x.Id == farm.Id);

            if (farmItem != null)
            {
                farmItem.Name = farm.Name;
                farmItem.Department = farm.Department;
                farmItem.Country = farm.Country;
                farmItem.Municipality = farm.Municipality;
                farmItem.TotalArea = farm.TotalArea;
                farmItem.CreatedDate = farm.CreatedDate;
                farmItem.Crops = farm.Crops;
                farmItem.Employees = farm.Employees;
                farmItem.Activities = farm.Activities;
                farmItem.Inventory = farm.Inventory;
                farmItem.FarmProductions = farm.FarmProductions;
                await _context.SaveChangesAsync();
            }

        }

    }
}
