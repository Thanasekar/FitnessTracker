using System.ComponentModel.DataAnnotations;

namespace UserActivityService.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
    }
}
