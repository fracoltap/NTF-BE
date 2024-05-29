namespace NTF_BE.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean EmailConfirmed { get; set; }
    }
}
