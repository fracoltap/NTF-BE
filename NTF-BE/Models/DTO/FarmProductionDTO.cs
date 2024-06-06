namespace NTF_BE.Models.DTO
{
    public class FarmProductionDTO
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public int ProductId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ProducedQuantity { get; set; }
        public string Unit { get; set; }
    }
}
