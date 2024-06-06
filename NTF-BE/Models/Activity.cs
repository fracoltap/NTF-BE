namespace NTF_BE.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
