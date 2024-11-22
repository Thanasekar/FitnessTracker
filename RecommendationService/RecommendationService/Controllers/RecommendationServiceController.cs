using Microsoft.AspNetCore.Mvc;
using RecommentationService.Services;

namespace RecommendationService.Controllers
{
    [ApiController]
    [Route("api/Recommendation")]
    public class RecommendationServiceController : ControllerBase
    {
        private readonly IRecommentationDataService _recommendationService;

        public RecommendationServiceController(IRecommentationDataService recommendationService)
        { 
            _recommendationService = recommendationService;
        }
        [HttpGet("{id}")]
        public IActionResult GetUserAccountById([FromRoute] Guid id)
        {
            var recommendation = _recommendationService.GenerateRecommendation(id);
           
            return StatusCode(StatusCodes.Status201Created, recommendation);
        }
       
    }
    
}
