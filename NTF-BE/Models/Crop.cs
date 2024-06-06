namespace NTF_BE.Models
{
    public class Crop
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public double CultivatedArea { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
