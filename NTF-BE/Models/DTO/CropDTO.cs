namespace NTF_BE.Models.DTO
{
    public class CropDTO
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public double CultivatedArea { get; set; }
    }
}
