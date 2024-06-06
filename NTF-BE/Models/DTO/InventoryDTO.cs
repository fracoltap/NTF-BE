namespace NTF_BE.Models.DTO
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
