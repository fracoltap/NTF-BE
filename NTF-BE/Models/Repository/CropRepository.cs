using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class CropRepository : ICropRepository
    {

        private readonly AplicationDbContext _context;

        public CropRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Crop> AddCrop(Crop crop)
        {
            _context.Add(crop);
            await _context.SaveChangesAsync();
            return crop;
        }

        public async Task DeleteCrop(Crop crop)
        {
            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Crop>> GetListCrops()
        {
            return await _context.Crops.ToListAsync();
        }

        public async Task<Crop> GetCrop(int id)
        {
            return await _context.Crops.FindAsync(id);
        }

        public async Task UpdateCrop(Crop crop)
        {
            var cropItem = await _context.Crops.FirstOrDefaultAsync(x => x.Id == crop.Id);

            if (cropItem != null)
            {
                cropItem.Name = crop.Name;
                cropItem.CultivatedArea = crop.CultivatedArea;             

                await _context.SaveChangesAsync();
            }

        }

    }
}
