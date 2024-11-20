using HealthMetricsService.Entities;
using HealthMetricsService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthMetricsService.Controllers
{
    [ApiController]
    [Route("api/HealthMetrics")]
    public class HealthMetricsController : ControllerBase
    {
        private readonly IHealthMetricsDetailService _healthMetricsDetailService;

        public HealthMetricsController(IHealthMetricsDetailService healthMetricsDetailService)
        {
            _healthMetricsDetailService = healthMetricsDetailService; 
        }
        [HttpGet("{id}")]
        public IActionResult GetUserAccountById([FromRoute] Guid id)
        {
            var userDetailResponse = _healthMetricsDetailService.GetHealthMetricsDetailById(id);

            return StatusCode(StatusCodes.Status200OK, userDetailResponse);
        }

        [HttpGet]
        public IActionResult GetAllUserDetails()
        {
            var userDetails = _healthMetricsDetailService.GetAllUSerHealthMetrics();
            if (userDetails.Count == 0)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, userDetails);
        }

        // POST: UserActivityDetailController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HealthMetricsCreateDto user)
        {

            var userDetail = _healthMetricsDetailService.CreateHealthMetricsDetail(user);
            return StatusCode(StatusCodes.Status201Created, userDetail);
            
        }
    }
    
}
