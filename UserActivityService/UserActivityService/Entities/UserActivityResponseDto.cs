namespace UserActivityService.Entities
{
    public class UserActivityResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long Phone { get; set; }
        public int Steps { get; set; }
        public int ExerciseMinutes { get; set; }
        public DateTime Date { get; set; }

    }
}
