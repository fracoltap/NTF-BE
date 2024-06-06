namespace NTF_BE.Models.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
