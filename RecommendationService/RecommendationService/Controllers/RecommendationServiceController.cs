using Microsoft.AspNetCore.Mvc;
using RecommendationService.Entities;
using RecommendationService.Models;
using RecommentationService.Services;

namespace RecommendationService.Controllers
{
    [ApiController]
    [Route("api/UserDetail")]
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
            //var userDetailResponse = _recommendationService.GetRecommendationById(id);

            //return StatusCode(StatusCodes.Status200OK, userDetailResponse);

            var recommendation = _recommendationService.GenerateRecommendation(id);

            //var userDetail = _recommendationService.CreateRecommendation(recommendation);
            return StatusCode(StatusCodes.Status201Created, recommendation);
        }

        // POST: UserDetailController/Create
        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] RecommendationCreateDto recommendationDto)
        //{
        //    var recommendation = _recommendationService.GenerateRecommendation(recommendationDto.Id);

        //    var userDetail = _recommendationService.CreateRecommendation(recommendation);
        //    return StatusCode(StatusCodes.Status201Created, userDetail);
            
        //}
    }
    
}
