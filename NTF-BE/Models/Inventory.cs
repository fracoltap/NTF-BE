    namespace NTF_BE.Models
    {
        public class Inventory
        {
            public int Id { get; set; }
            public int FarmId { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public DateTime CreatedDate { get; set; }

        }
    }
