namespace NTF_BE.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public bool IsActive { get; set; }
    }
}
