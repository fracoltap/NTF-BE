namespace NTF_BE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean EmailConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
