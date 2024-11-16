namespace UserService.Entities
{
    public class UserDetailResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long Phone { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
