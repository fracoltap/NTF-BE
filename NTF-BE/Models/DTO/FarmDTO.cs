namespace NTF_BE.Models.DTO
{
    public class FarmDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; } 
        public string Country { get; set; }
        public string Municipality { get; set; }
        public double TotalArea { get; set; }
        public List<Crop> Crops { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Inventory> Inventory { get; set; }
        public List<FarmProduction> FarmProductions { get; set; }
    }
}
