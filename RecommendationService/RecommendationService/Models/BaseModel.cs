using System.ComponentModel.DataAnnotations;

namespace RecommendationService.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
