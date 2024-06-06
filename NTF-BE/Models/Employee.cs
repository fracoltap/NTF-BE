namespace NTF_BE.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
