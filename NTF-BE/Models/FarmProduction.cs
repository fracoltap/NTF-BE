namespace NTF_BE.Models
{
    public class FarmProduction
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public int ProductId { get; set; }
        public int Month { get; set; } 
        public int Year { get; set; }
        public int ProducedQuantity { get; set; }
        public string Unit { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
