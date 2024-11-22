using System.ComponentModel.DataAnnotations;

namespace HealthMetricsService.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
