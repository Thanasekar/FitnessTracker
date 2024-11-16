using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
